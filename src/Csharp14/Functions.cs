using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp15.Csharp14
{
    public class Functions
    {
        private int[] a = new[] { 16, 16, 95, 8, 54, 71, 84, 93, 25, 46,
                                    53, 50, 96, 52, 61, 40, 6, 71, 2, 69,
                                    91, 82, 53, 76, 7, 84, 68, 94, 12, 89
                                };
        private int[] b = new[] { 2, 80, 35, 11, 35, 83, 94, 95, 84, 11,
                                     82, 48, 91, 10, 86, 90, 58, 46, 46, 82,
                                     78, 60, 56, 75, 76, 94, 49, 56, 12, 46,
                                     29, 17, 35, 89, 19
                                };
        public IEnumerable<int> ArraySum()
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

                return c;
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

                return c;
            }
        }

        public IEnumerable<int> ExtensionMethodWithDelegateSum()
        {
            return a + b;
        }
    }
}
