using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Factorial(5);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
