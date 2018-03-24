using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher.Csv
{
    /// <summary>
    /// Airport list with location.
    /// </summary>
    public class AirportService
    {
        private static List<AirportModel> _airports;

        static AirportService()
        {
            using (var textReader = File.OpenText("airports.csv"))
            {
                var csv = new CsvReader(textReader);
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<AirportClassMap>();

                _airports = csv.GetRecords<AirportModel>()
                    .ToList();
            }
        }

        public AirportModel GetByCode(string code)
        {
            var result = _airports
                .FirstOrDefault(a => a.AirportCode == code);

            return result;
        }
    }
}
