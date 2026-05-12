using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp15.Csharp14
{
    public static class Enumerable
    {
        extension(IEnumerable<int> sequence)
        {
            public static IEnumerable<int> operator +(IEnumerable<int> left, IEnumerable<int> right) => left.Merge(right, (x, y) => x + y);
        }
    }

    public static class FileExtensions
    {
        extension(File)
        {
            public static void SayHello(string text)
            {
                Console.WriteLine($"Hello File: {text}");
            }
        }
    }


}
