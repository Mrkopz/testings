using FlightSearcher.Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class GreedySolverWithFakeFilghtTests
    {
        private ISolver CreateCheapestSolver()
        {
            var flightSearchService = new FakeFlightSearchService();
            var flightService = new CheapestRouteService(flightSearchService);
            var airportService = new AirportService();
            var solver = new GreedySolver(flightService, airportService);

            return solver;
        }

        private ISolver CreateFastestRouteSolver()
        {
            var flightSearchService = new FakeFlightSearchService();
            var flightService = new FastestRouteService(flightSearchService);
            var airportService = new AirportService();
            var solver = new GreedySolver(flightService, airportService);

            return solver;
        }

        [TestMethod]
        public void Test2CitiesCheapest()
        {
            var solver = CreateCheapestSolver();
            var cities = new string[] { "BKK", "LHR" };

            var result = solver.FindCheapestRoute(
                cities,
                DateTime.Now.Date.AddDays(3),
                DateTime.Now.Date.AddDays(5))
                .GetAwaiter().GetResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test3CitiesCheapest()
        {
            var solver = CreateCheapestSolver();
            var cities = new string[] { "BKK", "LHR", "BRU" };

            var result = solver.FindCheapestRoute(
                cities,
                DateTime.Now.Date.AddDays(3),
                DateTime.Now.Date.AddDays(7))
                .GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Sequence.Count);
            Assert.AreEqual(TimeSpan.FromHours(1), result.TotalWaitingInterval);
        }

        [TestMethod]
        public void Test5CitiesCheapest()
        {
            var solver = CreateCheapestSolver();
            var cities = new string[] { "BKK", "BRU", "LHR", "SIN", "HKG" };

            var result = solver.FindCheapestRoute(
                cities,
                DateTime.Now.Date.AddDays(3),
                DateTime.Now.Date.AddDays(15))
                .GetAwaiter().GetResult();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test2CitiesFastest()
        {
            var solver = CreateFastestRouteSolver();
            var cities = new string[] { "BKK", "LHR" };

            var result = solver.FindFastestRoute(
                cities,
                DateTime.Now.Date.AddDays(3),
                DateTime.Now.Date.AddDays(5))
                .GetAwaiter().GetResult();

            Assert.IsNotNull(result);

            var prettyResult = result.ToString();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(prettyResult));
        }

        [TestMethod]
        public void Test3CitiesFastest()
        {
            var solver = CreateFastestRouteSolver();
            var cities = new string[] { "BKK", "LHR", "BRU" };

            var result = solver.FindFastestRoute(
                cities,
                DateTime.Now.Date.AddDays(3),
                DateTime.Now.Date.AddDays(7))
                .GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Sequence.Count);
            Assert.AreEqual(TimeSpan.FromHours(1), result.TotalWaitingInterval);

            var prettyResult = result.ToString();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(prettyResult));
        }
    }
}
