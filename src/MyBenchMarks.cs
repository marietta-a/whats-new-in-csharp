using BenchmarkDotNet.Attributes;
using Csharp15.Csharp14;

namespace Csharp15
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