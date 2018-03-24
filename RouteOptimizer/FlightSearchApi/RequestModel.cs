using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher
{
    public class RequestModel
    {
        [JsonProperty(PropertyName = "affiliateCode")]
        public string AffiliateCode { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }

        [JsonProperty(PropertyName = "departDate")]
        public string DepartDate { get; set; }

        [JsonProperty(PropertyName = "adults")]
        public int Adults { get; set; }

        [JsonProperty(PropertyName = "cabinClass")]
        public string CabinClass { get; set; }

        [JsonProperty(PropertyName = "oneWayOrReturn")]
        public string OneWayOrReturn { get; set; }

        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }
    }
}
