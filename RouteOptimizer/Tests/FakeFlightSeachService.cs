using FlightSearcher;
using FlightSearcher.Csv;
using RouteOptimizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class FakeFlightSearchService : IFlightSearchService
    {
        private AirportService _airportService;
        private readonly int _priceRatePerKm = 10;
        private readonly int _secondsPerKm = 10;

        public string Currency
        {
            get
            {
                return "AUD";
            }
        }

        public FakeFlightSearchService()
        {
            _airportService = new AirportService();
        }

        public Task<List<FlightItinerary>> Get(string from, string to, DateTime departDate)
        {
            var fromAirport = _airportService.GetByCode(from);
            var toAirport = _airportService.GetByCode(to);
            var distance = Helper.CalculateDistance(
                fromAirport.Latitude, fromAirport.Longitude,
                toAirport.Latitude, toAirport.Longitude);

            var list = new List<FlightItinerary>()
            {
                new FlightItinerary()
                {
                    Price = new Price()
                    {
                        Amount = (decimal)distance * _priceRatePerKm
                    },

                    OutboundLeg = new OutboundLeg()
                    {
                        Segments = new List<FlightSegment>()
                        {
                            new FlightSegment()
                            {
                                DepartDateTime = departDate.AddMinutes(30),
                                ArriveDateTime = departDate
                                    .AddMinutes(30)
                                    .AddSeconds(distance * _secondsPerKm)
                            }
                        }
                    }
                }
            };

            return Task.FromResult(list);
        }
    }
}
