using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp15.Csharp14
{
    public static class MyEnumerable
    {
        public static IEnumerable<TResult> Merge<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {

            ArgumentNullException.ThrowIfNull(first);
            ArgumentNullException.ThrowIfNull(second);

            return MergeIterator(first, second, selector);
        }

        public static IEnumerable<TResult> MergeIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
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
    }
}
