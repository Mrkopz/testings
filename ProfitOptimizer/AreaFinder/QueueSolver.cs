using System;
using System.Collections.Generic;
using System.Text;

namespace AreaFinder
{
    public class QueueSolver
    {
        public static int Caculate(int[,] area, Tuple<int, int> startPoint)
        {
            Queue<Tuple<int, int>> reminingPoints = new Queue<Tuple<int, int>>();
            reminingPoints.Enqueue(startPoint);

            var areaCount = 0;

            while (reminingPoints.Count > 0)
            {
                var point = reminingPoints.Dequeue();

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
                    

                    area[point.Item1, point.Item2] = 0;

                    var pointUp = new Tuple<int, int>(point.Item1, point.Item2 - 1);
                    var pointDown = new Tuple<int, int>(point.Item1, point.Item2 + 1);
                    var pointRight = new Tuple<int, int>(point.Item1 + 1, point.Item2);
                    var pointLeft = new Tuple<int, int>(point.Item1 - 1, point.Item2);

                    reminingPoints.Enqueue(pointUp);
                    reminingPoints.Enqueue(pointDown);
                    reminingPoints.Enqueue(pointRight);
                    reminingPoints.Enqueue(pointLeft);
                } 

            }

            return areaCount;
        }
    }
}
