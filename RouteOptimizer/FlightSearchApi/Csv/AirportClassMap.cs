using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher.Csv
{
    public sealed class AirportClassMap : ClassMap<AirportModel>
    {
        public AirportClassMap()
        {
            Map(m => m.AirportName).Index(1);
            Map(m => m.AirportCode).Index(4);
            Map(m => m.Latitude).Index(6);
            Map(m => m.Longitude).Index(7);
        }
    }
}
