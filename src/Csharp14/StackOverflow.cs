using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Csharp.Csharp14
{
    public class StackOverflow
    {
        public List<object> dataList;
        public bool AddData(ref object data) { 
            bool success = false;
            try
            {
                // I've also used "if (data != null)" which hasn't worked either
                dataList?.Add(data);
                success = DoOtherStuff(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return success;
        }

        public bool DoOtherStuff(object data) {
            return true;
        }

    }

}
