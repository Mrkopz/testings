using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer.Models
{
    /// <summary>
    /// Model for store route between cities.
    /// </summary>
    public class Route
    {
        public string From { get; set; }

        public string To { get; set; }

        public string[] Flights { get; set; }

        public DateTime DepartDateTime { get; set; }

        public DateTime ArriveDateTime { get; set; }

        public TimeSpan TransitInterval
        {
            get
            {
                return ArriveDateTime - DepartDateTime;
            }
        }

        public TimeSpan WaitingInterval { get; set; }

        public decimal Price { get; set; }
    }
}
