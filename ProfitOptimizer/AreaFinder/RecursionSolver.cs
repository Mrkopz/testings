using System;
using System.Collections.Generic;
using System.Text;

namespace AreaFinder
{
    public class RecursionSolver
    {
        private readonly static int open = 1;
        private readonly static int block = 0;

        public static int Calculate(int[,] area, Tuple<int, int> startPoint)
        {
            if (startPoint.Item1 < 0 || startPoint.Item1 > area.GetUpperBound(0)
                || startPoint.Item2 < 0 || startPoint.Item2 > area.GetUpperBound(1))
                return 0;

            if (area[startPoint.Item1, startPoint.Item2] == open)
            {
                area[startPoint.Item1, startPoint.Item2] = block;
            }

            else
            {
                return 0;
            }

            int count = 1;

            count += Calculate(area, new Tuple<int, int>(startPoint.Item1, startPoint.Item2 + 1));
            count += Calculate(area, new Tuple<int, int>(startPoint.Item1, startPoint.Item2 - 1));
            count += Calculate(area, new Tuple<int, int>(startPoint.Item1 + 1, startPoint.Item2));
            count += Calculate(area, new Tuple<int, int>(startPoint.Item1 - 1, startPoint.Item2));

            return count;
        }
    }
}
