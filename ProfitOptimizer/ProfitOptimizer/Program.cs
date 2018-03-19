using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitOptimizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var data = new double[7] { 2.5, 1.20, 1.00, 1.50, 1.10, 0.90, 3.5 };
            double buy = 0, sell = 0;
            double previousBuy = data[0];
            int buyIndex = 0, sellIndex = 0;
            double previousSell = 0;

            var lastValue = data[data.Length - 1];

            foreach (var item in data)
            {
                if (previousBuy >= item && item != lastValue)
                {
                    buy = item;
                    previousBuy = item;

                }


            }

            buyIndex = Array.IndexOf(data, buy);
            sellIndex = buyIndex;

            foreach (var item in data)
            {
                if (previousSell <= item && buy <= item && buyIndex < sellIndex)
                {
                    sell = item;
                    previousSell = item;
                }

                sellIndex++;
            }

            Console.WriteLine($"Buy: { buy }, Sell: { sell }");
            Console.ReadLine();
        }

        //static void Main(string[] args)
        //{
        //    double[] data = { 2.5, 1.20, 1.00, 1.50, 1.10, 0.90, 3.5 };
        //    double previousBuy = data[0];

        //    double total = Recursive(data, previousBuy);


        //    Console.WriteLine(total);
        //    Console.ReadLine();
        //}

        //static double Recursive(double[] value, double previousBuy, int index = 0)
        //{
        //    double lastValue = value[value.Length - 1];

        //    var currentValue = value[index];
        //    if (previousBuy < currentValue  && lastValue != currentValue)
        //    {
        //        return value.GetLowerBound(0);
        //    }

        //    previousBuy = currentValue;

        //    return Recursive(value, previousBuy, index + 1);
        //}

    }
}
