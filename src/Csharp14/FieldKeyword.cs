using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp15.Csharp14
{
    public class FieldKeyword
    {
        public string Message
        {
            get;
            set => field = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
