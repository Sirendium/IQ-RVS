using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSpyApplication
{
   public class Log
    {
       public static void Error(string _str)
       {
           Console.WriteLine(_str);
       }

       internal static void Debug(string _str)
       {
           Console.WriteLine(_str);
       }
    }
}
