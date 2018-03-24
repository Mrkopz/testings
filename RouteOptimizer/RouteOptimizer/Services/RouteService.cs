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
    /// Find routes between cities.
    /// Results are cached for better performance.
    /// </summary>
    public abstract class RouteService
    {
        protected IFlightSearchService _flightSearchService;
        private MemoryCache _cache = new MemoryCache("MyTestCache");

        public RouteService(IFlightSearchService flightSearchService)
        {
            _flightSearchService = flightSearchService;
        }

        protected async Task<IEnumerable<Route>> Find(
            string from, string to,
            DateTime date)
        {
            var cacheKey = new RouteCacheKey()
            {
                From = from,
                To = to,
                Date = date
            };

            var cacheItem = _cache[cacheKey.ToString()];
            IEnumerable<Route> route;

            if (cacheItem != null)
            {
                route = (IEnumerable<Route>)cacheItem;
            }

            else
            {
                var webFlights = await _flightSearchService.Get(from, to, date);

                route = webFlights
                    .Select(f => Map(from, to, date, f));

                _cache.Add(cacheKey.ToString(), route.ToList(), date.AddDays(1));
            }

            return route
                .Where(f => f.DepartDateTime > date);
        }

        private Route Map(
            string from, string to, DateTime periodStart,
            FlightItinerary flight)
        {
            var departDateTime = flight.OutboundLeg.Segments.First().DepartDateTime;
            var arriveDateTime = flight.OutboundLeg.Segments.Last().ArriveDateTime;
            var waitingTime = TimeSpan.Zero;

            foreach (var segment in flight.OutboundLeg.Segments)
            {
                waitingTime += segment.DepartDateTime - periodStart;
                periodStart = segment.ArriveDateTime;
            }

            return new Route()
            {
                From = from,
                To = to,
                Flights = flight.OutboundLeg.Segments
                            .Select(s => s.FlightNumber)
                            .ToArray(),
                Price = flight.Price.Amount,
                DepartDateTime = departDateTime,
                ArriveDateTime = arriveDateTime,
                WaitingInterval = waitingTime
            };
        }
    }
}
