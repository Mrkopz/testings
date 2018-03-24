using RouteOptimizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer.Services
{
    public interface ISolver
    {
        /// <summary>
        /// Find fastest route by giving set of city.
        /// </summary>
        /// <param name="citySet"></param>
        /// <param name="periodStart">Period start</param>
        /// <param name="periodEnd">Period end</param>
        /// <returns>Returns null if no fessible solution.</returns>
        Task<Solution> FindFastestRoute(string[] citySet, DateTime periodStart, DateTime periodEnd);

        /// <summary>
        /// Find cheapest route by giving set of city.
        /// </summary>
        /// <param name="citySet"></param>
        /// <param name="periodStart"></param>
        /// <param name="periodEnd"></param>
        /// <returns>Returns null if no fessible solution.</returns>
        Task<Solution> FindCheapestRoute(string[] citySet, DateTime periodStart, DateTime periodEnd);
    }
}
