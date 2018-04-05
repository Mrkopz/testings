using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pow(5, 4));
            Console.ReadLine();
        }

        private static int Pow(int number, int pow)
        {
            int countLoop = 0;
            int loop = number;
            int result = 0;
            for (int i = 1; i < pow; i++)
            {
                for (int j = 0; j < loop; j++)
                {
                    countLoop += number;
                }

                loop = countLoop;
                result = countLoop;

                countLoop = 0;
                
            }

            return result;
        }
    }
}
