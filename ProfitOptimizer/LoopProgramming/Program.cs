using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    result += i.ToString();
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
