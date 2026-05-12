using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{
    public class Recursion
    {
        public int SumOfNumbers(int numbers)
        {
            if (numbers == 1) return 1;

            return numbers + SumOfNumbers(numbers - 1);
        }
    }
}
