using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher
{
    public class FlightItinerary
    {
        [JsonProperty(PropertyName = "price")]
        public Price Price { get; set; }

        [JsonProperty(PropertyName = "outboundLeg")]
        public OutboundLeg OutboundLeg { get; set; }
    }

    public class Price
    {
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
    }

    public class OutboundLeg
    {
        [JsonProperty(PropertyName = "segments")]
        public List<FlightSegment> Segments { get; set; }
    }

    public class FlightSegment
    {
        [JsonProperty(PropertyName = "flightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty(PropertyName = "departPortCode")]
        public string DepartPortCode { get; set; }

        [JsonProperty(PropertyName = "departDttm")]
        public DateTime DepartDateTime { get; set; }

        [JsonProperty(PropertyName = "arrivePortCode")]
        public string ArrivePortCode { get; set; }

        [JsonProperty(PropertyName = "arriveDttm")]
        public DateTime ArriveDateTime { get; set; }
    }
}
