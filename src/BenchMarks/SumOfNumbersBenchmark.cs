using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp.BenchMarks
{
    public class SumOfNumbersBenchmark
    {
        [Benchmark]
        [Arguments(100)]
        public int SumOfNumbersByRecursion(int numbers)
        {
            var recursion = new Recursion();
            return recursion.SumOfNumbers(numbers);
        }

        [Benchmark]
        [Arguments(100)]
        public int SumOfNumbersByEnumeration(int numbers)
        {
            return Enumerable.Range(1, numbers).Sum();
        }

        [Benchmark]
        [Arguments(100)]
        public int SumOfNumbersByLoop(int numbers)
        {
            var sum = 0;
            for(var i = 1; i <= numbers; i++)
            {
                sum += i;
            }
            return sum;
        }

        [Benchmark]
        [Arguments(100)]
        public int SumOfNumbersByFunction(int numbers)
        {
            return numbers * (numbers + 1) / 2;
        }
    }
}
