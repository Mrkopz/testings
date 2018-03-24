using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher.Csv
{
    public class AirportModel
    {
        public string AirportName { get; set; }

        public string AirportCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
