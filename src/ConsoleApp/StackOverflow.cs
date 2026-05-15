using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class StackOverflow
    {
        public void CheckSession(Dictionary<string, object?> session)
        {

            string y = session["key"]?.ToString() ?? "none";

            Console.WriteLine(y);

        }
    }
}
