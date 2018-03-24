using System;
using System.Collections;
using System.Collections.Generic;

namespace AreaFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var area = new int[,]
            {
                { 0, 1, 0, 1 },
                { 1, 1, 1, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 0, 1 }
            };

            var queueInput = area.Clone() as int[,];
            var queueResult = QueueSolver.Caculate(queueInput, new Tuple<int, int>(1, 0));
            Console.WriteLine($"Queue solver : {queueResult}");

            var stackInput = area.Clone() as int[,];
            var stackResult = QueueSolver.Caculate(stackInput, new Tuple<int, int>(1, 0));
            Console.WriteLine($"Stack solver : {stackResult}");

            var recursionInput = area.Clone() as int[,];
            var recursionResult = RecursionSolver.Calculate(recursionInput, new Tuple<int, int>(1, 0));
            Console.WriteLine($"Recursion solver : {recursionResult}");

            Console.ReadLine();
        }
    }
}
