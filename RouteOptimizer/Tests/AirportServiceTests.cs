using FlightSearcher.Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AirportServiceTests
    {
        [TestMethod]
        public void TestGetByAirportCode()
        {
            var service = new AirportService();
            var model = service.GetByCode("BKK");

            Assert.IsNotNull(model);
            Assert.AreEqual("BKK", model.AirportCode);
        }
    }
}
