# Why My C# 14 Extension Operator Ran 37x Faster - And Why That's Slightly Misleading

I've been exploring C# 14's new `extension` block syntax, and I decided to benchmark it against the old-school manual approach. The result was striking - and instructive.

---

## The Setup

I have two integer arrays of different lengths:

```csharp
private int[] a = new[] { 16, 16, 95, 8, 54, 71, 84, 93, 25, 46, ... }; // 30 elements
private int[] b = new[] { 2, 80, 35, 11, 35, 83, 94, 95, 84, 11, ... }; // 35 elements
```

The goal: add corresponding elements together. If one array is shorter than the other, treat the missing slots as zero.

---

## The Old Way - Manual Loop

```csharp
public void BenchmarkArraySum()
{
    if (a.Length > b.Length)
    {
        int[] c = new int[a.Length];
        for (var i = 0; i < a.Length; i++)
        {
            var sum = a[i];
            if (i > b.Length - 1)
                c[i] = sum;
            else
                c[i] = sum + b[i];
        }
    }
    else
    {
        int[] c = new int[b.Length];
        for (var i = 0; i < b.Length; i++)
        {
            var sum = b[i];
            if (i > a.Length - 1)
                c[i] = sum;
            else
                c[i] = sum + a[i];
        }
    }
}
```

Straightforward. Check which array is longer, allocate a result array, loop, add. Done.

---

## The C# 14 Way - Extension Operators

C# 14 introduces `extension` blocks, which let you define extension members - including operators - on types you don't own. Here I'm overloading `+` on `IEnumerable<int>`:

```csharp
public static class Enumerable
{
    extension(IEnumerable<int> sequence)
    {
        public static IEnumerable<int> operator +(IEnumerable<int> left, IEnumerable<int> right)
            => left.Merge(right, (x, y) => x + y);
    }
}
```

The `Merge` method uses `yield return` to walk both sequences in parallel, filling missing values with the type's default (zero for `int`):

```csharp
public static IEnumerable<TResult> MergeIterator<TFirst, TSecond, TResult>(
    IEnumerable<TFirst> first, IEnumerable<TSecond> second,
    Func<TFirst, TSecond, TResult> selector)
{
    using var firstEnum = first.GetEnumerator();
    using var secondEnum = second.GetEnumerator();

    bool hasFirst = firstEnum.MoveNext();
    bool hasSecond = secondEnum.MoveNext();

    while (hasFirst || hasSecond)
    {
        TFirst firstVal = hasFirst ? firstEnum.Current : default!;
        TSecond secondVal = hasSecond ? secondEnum.Current : default!;

        yield return selector(firstVal, secondVal);

        hasFirst = hasFirst && firstEnum.MoveNext();
        hasSecond = hasSecond && secondEnum.MoveNext();
    }
}
```

The benchmark call looks beautifully simple:

```csharp
public void BenchmarkExtensionMethodWithDelegateSum()
{
    var arrSum = a + b;
}
```

---

## The Results

| Method                                  | Mean     | Error    | StdDev   |
|-----------------------------------------|----------|----------|----------|
| BenchmarkArraySum                       | 45.280ns | 0.9142ns | 1.2816ns |
| BenchmarkExtensionMethodWithDelegateSum |  1.207ns | 0.0521ns | 0.0535ns |

**37x faster.** That's a dramatic gap - and it deserves an honest explanation.

---

## Why the Extension Method "Won" - The Real Story

The extension method version is fast because `yield return` makes it **lazy**. When you write `var arrSum = a + b;`, you get back an iterator object - a promise to compute the sums. No elements are actually summed yet. The work happens only when something enumerates `arrSum`, like a `foreach` loop or `.ToList()`.

The benchmark, as written, never enumerates the result. So what's being measured is the cost of **setting up the state machine**, not the actual summation. The manual loop, by contrast, does all the work immediately - allocating a `b.Length`-sized array on the heap and filling every slot before returning.

This means the benchmark is really comparing two different things:

- **BenchmarkArraySum**: fully computes and materializes the result
- **BenchmarkExtensionMethodWithDelegateSum**: defers all computation

If you added `.ToList()` to the extension method call, the picture would look very different. You'd pay the enumerator setup cost, the delegate call overhead per element, and heap allocation for the list - likely making it *slower* than the array approach.

---

## What This Actually Demonstrates

Despite the benchmark caveat, this experiment highlights something genuinely powerful about C# 14 extension blocks: **they let you compose readable, operator-level syntax on top of lazy pipelines**. Writing `a + b` instead of a nested if/else with manual index tracking is a real ergonomic win.

The lazy model also shines in pipeline scenarios - if you're chaining multiple sequence operations and only need the first few results, deferred evaluation means you skip a lot of unnecessary work.

The lesson: syntax that looks faster isn't always faster end-to-end. But syntax that's cleaner *and* composable can absolutely be the right choice - as long as you understand when the work actually runs.

---

*Benchmarks run on BenchmarkDotNet v0.15.8 · .NET 10.0.5 · Intel Core i7-10850H 2.70GHz · Windows 11*

---

*Note: The code in this article was written without AI assistance. The article itself was drafted with the help of AI.*
