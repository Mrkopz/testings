﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AreaFinder
{
    public class StackSolver
    {
        public static int Solver(int[,] area, Tuple<int, int> startPoint)
        {
            Stack<Tuple<int, int>> remainingPoints = new Stack<Tuple<int, int>>();
            remainingPoints.Push(startPoint);
            var areaCount = 0;

            while (remainingPoints.Count > 0)
            {
                var point = remainingPoints.Pop();
                if (point.Item1 < 0 || point.Item2 < 0 || point.Item1 > area.GetUpperBound(0) || point.Item2 > area.GetUpperBound(1))
                {
                    continue;
                }

                if (area[point.Item1, point.Item2] == 0)
                {
                    continue;
                }
                else
                {
                    areaCount++;
                    var pointUp = new Tuple<int, int>(point.Item1, point.Item2 - 1);
                    var pointDown = new Tuple<int, int>(point.Item1, point.Item2 + 1);
                    var pointRight = new Tuple<int, int>(point.Item1 + 1, point.Item2);
                    var pointLeft = new Tuple<int, int>(point.Item1 - 1, point.Item2);

                    remainingPoints.Push(pointUp);
                    remainingPoints.Push(pointDown);
                    remainingPoints.Push(pointRight);
                    remainingPoints.Push(pointLeft);

                    area[point.Item1, point.Item2] = 0;
                }

            }

            return areaCount;
        }
    }
}
