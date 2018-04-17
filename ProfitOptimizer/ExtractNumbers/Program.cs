using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var result = ExtractNumbers("10, 150, -7, 0, 99");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            var rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                var value = rnd.Next(1, 11);
                if (value % 2 == 0)
                {
                    Console.WriteLine($"{ value } EVEN");
                }
                else
                {
                    Console.WriteLine($"{ value } ODD");
                }
            }
            
            Console.ReadLine();
        }

        public static int[] ExtractNumbers(string input)
        {
            var strArrary = input.Split(',');

            if (strArrary == null || strArrary.Length <= 0)
                return null;

            var numbers = new int[strArrary.Length];

            for (int i = 0; i < strArrary.Length; i++)
            {
                numbers[i] = int.Parse(strArrary[i]);
            }

            return numbers;
        }

        
    }
}
