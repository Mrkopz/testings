using FlightSearcher;
using RouteOptimizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer.Services
{
    /// <summary>
    /// Find the fastest flight.
    /// </summary>
    public class FastestRouteService : RouteService, IRoutetService
    {
        public string Currency
        {
            get
            {
                return _flightSearchService.Currency;
            }
        }

        public FastestRouteService(IFlightSearchService flightSearchService)
            : base(flightSearchService)
        {

        }

        public async Task<Route> Find(
            string from, string to,
            DateTime periodStart, DateTime periodEnd)
        {
            var routes = await Find(from, to, periodStart);

            var fastestRoute = routes
                    .Where(f => f.ArriveDateTime < periodEnd)
                    .OrderBy(f => f.TransitInterval + f.WaitingInterval)
                    .FirstOrDefault();

            return fastestRoute;
        }
    }
}
