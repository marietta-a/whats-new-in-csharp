using BenchmarkDotNet.Attributes;
using Csharp15.Csharp14;
using Enumerable = System.Linq.Enumerable;

namespace Csharp.BenchMarks
{
    public class MyBenchMarks
    {
        private readonly Functions _functions = new Functions();

        [Benchmark]
        public IEnumerable<int> BenchmarkArraySum()
        {
            return _functions.ArraySum();
        }

        [Benchmark]
        public IEnumerable<int> BenchmarkExtensionMethodWithDelegateSum()
        {
            return _functions.ExtensionMethodWithDelegateSum();
        }

    }
}