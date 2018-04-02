using System;
using System.Collections.Generic;
using System.Linq;

namespace BSC.Code.Library.Utils
{
    public class BDD_Result
    {
        public static List<int> ArrayOfInteger(int initial, int final)
        {
            return Enumerable.Range(initial , final).ToList();
        }

        public static void PrintOutPut(int itemOfArray)
        {
            
            if ((itemOfArray % 3 == 0) && (itemOfArray % 10 == 6))
            {
                Console.WriteLine(String.Format("{0} multiple of 3, ends in 6", itemOfArray));
             }
            else if (itemOfArray % 3 == 0)
            {
                Console.WriteLine(String.Format("{0} multiple of 3", itemOfArray));
            }
            else if (itemOfArray % 10 == 6)
            {
                Console.WriteLine(String.Format("{0} ends in 6", itemOfArray));
            }
            else
            {
                Console.WriteLine(itemOfArray);

            }

        }

    }
}
