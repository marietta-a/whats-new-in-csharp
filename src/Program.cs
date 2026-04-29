using Csharp15;


/// Sum elements in the same index of two array sequences, 
/// if one sequence is shorter, the missing elements are replaced with default value of the element type (0 for int).

var functions = new MyBenchMarks();

Console.WriteLine($"Array Sum: {string.Join(", ", functions.BenchmarkArraySum())}");
Console.WriteLine($"Extension Method With Delegate Sum: {string.Join(", ", functions.BenchmarkExtensionMethodWithDelegateSum())}");
//BenchmarkDotNet.Running.BenchmarkRunner.Run<MyBenchMarks>();