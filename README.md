# C# Language Features — Code Samples

A hands-on reference repo showcasing new language features introduced across recent C# versions, with working code samples and benchmarks.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Project Structure

```
src/
├── Csharp14/
│   ├── Extensions.cs       # Extension members (new extension block syntax)
│   ├── FieldKeyword.cs     # field keyword in semi-auto properties
│   └── Merger.cs           # Merge/ZipLongest helper for sequences
├── MyBenchMarks.cs         # BenchmarkDotNet benchmarks
└── Program.cs              # Entry point (runs benchmarks)
```

## C# 14

### `field` Keyword in Semi-Auto Properties

The `field` keyword gives you access to the compiler-generated backing field directly inside a property accessor — without declaring the field yourself.

```csharp
public class FieldKeyword
{
    public string Message
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    }
}
```

Previously, adding any custom logic to a setter required declaring an explicit backing field and rewriting both accessors. Now you can customize just the setter while keeping the auto-generated getter.

---

### Extension Members

C# 14 introduces a new `extension` block syntax that replaces the old `static class` + `this` pattern for extension methods. It also unlocks extension *operators* and extension *properties* — things that were impossible before.

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

This defines `+` as an extension operator on `IEnumerable<int>`, allowing sequences of different lengths to be summed element-wise (shorter sequence is padded with the type's default value):

```csharp
int[] a = { 1, 2, 3 };
int[] b = { 10, 20 };

var result = a + b; // { 11, 22, 3 }
```

---

## Benchmarks

The project uses [BenchmarkDotNet](https://benchmarkdotnet.org/) to compare the manual loop implementation against the extension operator approach.

```
| Method                              | Mean     |
|------------------------------------ |---------:|
| BenchmarkArraySum                   | XX.XX ns |
| BenchmarkExtensionMethodWithDelegate| XX.XX ns |
```

Run benchmarks in Release mode:

```bash
dotnet run --project src -c Release
```

## Running the Samples

```bash
dotnet run --project src -c Release
```
