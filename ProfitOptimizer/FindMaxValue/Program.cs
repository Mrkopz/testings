﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrary = new int[] { 1, 5, 4, 3, 2, 6, 10, 8, 9, 7 };

            var result = GetMaxTwo(arrary);
            var output = string.Format("first value: {0}, second value: {1}", result.Item1, result.Item2);

            Console.WriteLine(output);
            Console.ReadLine();
        }

        

        private static Tuple<int, int> GetMaxTwo(IEnumerable<int> values)
        {
            var firstValue = int.MinValue;
            var secondValue = int.MinValue;

            foreach (var value in values)
            {
                if (value > firstValue)
                {
                    secondValue = firstValue;
                    firstValue = value;
                }
                else if (value > secondValue)
                {
                    secondValue = value;
                }
            }

            return new Tuple<int, int>(firstValue, secondValue);
        }

        private static int index = 0;
        private static int firstValue = int.MinValue;
        private static int secondValue = int.MinValue;

        private static Tuple<int, int> GetMaxTwoRecursion(IEnumerable<int> values)
        {
            var valueArray = values.ToArray();

            if (index == valueArray.Length)
            {
                return new Tuple<int, int>(firstValue, secondValue);
            }

            if (valueArray[index] > firstValue)
            {
                secondValue = firstValue;
                firstValue = valueArray[index];
            }
            else if (valueArray[index] > secondValue)
            {
                secondValue = valueArray[index];
            }

            index++;

            return GetMaxTwo(values);
        }
    }
}
