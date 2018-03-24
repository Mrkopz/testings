using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSearcher
{
    public interface IFlightSearchService
    {
        string Currency { get; }

        Task<List<FlightItinerary>> Get(string from, string to, DateTime departDate);
    }
}