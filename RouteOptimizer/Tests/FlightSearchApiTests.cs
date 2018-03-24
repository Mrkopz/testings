using System;
using FlightSearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FlightSearchApiTests
    {
        [TestMethod]
        public void TestSearchBkkToLon()
        {
            var service = new FlightSearchWebService("AUD", "Economy");

            var result = service.Get("BKK", "LHR", DateTime.Now.Date.AddDays(3))
                .GetAwaiter().GetResult();

            Assert.AreEqual(true, result.Count > 0);
        }
    }
}
