using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = GCD(12, 100);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
