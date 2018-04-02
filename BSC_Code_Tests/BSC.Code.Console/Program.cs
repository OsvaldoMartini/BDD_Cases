using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSC.Code.Library.Utils;

namespace BSC.Code.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayOfInteger = BDD_Result.ArrayOfInteger(1,100);

            foreach (var item in arrayOfInteger)
            {
                BDD_Result.PrintOutPut(item);
            }

            System.Console.ReadKey();
        }
    }
}
