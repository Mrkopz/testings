using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSearcher.Csv;
using RouteOptimizer.Models;
using RouteOptimizer.Properties;

namespace RouteOptimizer.Services
{
    /// <summary>
    /// Pick next city by lowest value of cost function.
    /// Fast but not give the optimal solution.
    /// </summary>
    public class GreedySolver : ISolver
    {
        private readonly int _nextCityLimit = 3;

        private IRoutetService _routeService;
        private AirportService _airportService;
        private Func<string, string, double> _approxCostFunc;

        public GreedySolver(
            IRoutetService routeService,
            AirportService airportService)
        {
            _routeService = routeService;
            _airportService = airportService;

            _approxCostFunc = (from, to) =>
            {
                var fromAirport = _airportService.GetByCode(from);
                var toAirport = _airportService.GetByCode(to);
                var distance = Helper.CalculateDistance(
                    fromAirport.Latitude, fromAirport.Longitude,
                    toAirport.Latitude, toAirport.Longitude);

                return distance;
            };
        }

        private async Task<Solution> FindSolution<TCost>(
            string startCity, List<string> remainingCities,
            DateTime periodStart, DateTime periodEnd,
            Func<Route, TCost> costPropertyFunc)
                where TCost : struct
        {
            var solution = new Solution()
            {
                Currency = _routeService.Currency
            };

            while (remainingCities.Any())
            {
                var route = await Task.WhenAll(remainingCities
                    .OrderBy(c => _approxCostFunc(startCity, c))
                    .Take(_nextCityLimit)
                    .Select(remainingCity =>
                        _routeService.Find(
                            startCity, remainingCity,
                            periodStart, periodEnd)));

                if (route.All(f => f == null))
                {
                    periodStart = periodStart.Date.AddDays(1);

                    if (periodStart <= periodEnd)
                        continue;
                    else
                        break;
                }

                var bestNextFlight = route
                    .Where(f => f != null)
                    .OrderBy(costPropertyFunc)
                    .First();

                solution.Sequence.Add(bestNextFlight);

                startCity = bestNextFlight.To;
                remainingCities.Remove(startCity);
                periodStart = bestNextFlight.ArriveDateTime
                    .AddDays(Settings.Default.NumberOfDaysToStayAtEachCity);
            }

            if (!remainingCities.Any())
                return solution;
            else
                return null;
        }

        private async Task<Solution[]> FindSolutions<TCost>(
            string[] citySet, 
            DateTime periodStart, DateTime periodEnd,
            Func<Route, TCost> costPropertyFunc)
                where TCost : struct
        {
            var solutions = citySet.Select(startCity =>
            {
                var remainingCities = citySet.Where(c => c != startCity)
                    .ToList();

                return FindSolution(startCity, remainingCities,
                    periodStart, periodEnd,
                    costPropertyFunc);
            })
            .Where(s => s != null)
            .ToList();

            return await Task.WhenAll(solutions);
        }

        public async Task<Solution> FindCheapestRoute(
            string[] citySet, DateTime periodStart, DateTime periodEnd)
        {
            var solutions = await FindSolutions(
                citySet, periodStart, periodEnd,
                x => x.Price);

            return solutions.OrderBy(s => s.TotalPrice).FirstOrDefault();
        }

        public async Task<Solution> FindFastestRoute(
            string[] citySet, DateTime periodStart, DateTime periodEnd)
        {
            var solutions = await FindSolutions(
                citySet, periodStart, periodEnd,
                x => x.TransitInterval + x.WaitingInterval);

            return solutions.OrderBy(s => s.TotalInterval).FirstOrDefault();
        }
    }
}
