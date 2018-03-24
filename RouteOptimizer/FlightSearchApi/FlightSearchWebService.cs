using FlightSearcher.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearcher
{
    /// <summary>
    /// Flight search by Jetaboard API.
    /// </summary>
    public class FlightSearchWebService : IFlightSearchService
    {
        private HttpClient _client = new HttpClient();
        private readonly string _currency;
        private readonly string _cabinClass;

        public string Currency
        {
            get
            {
                return _currency;
            }
        }

        public FlightSearchWebService(
            string currency, string cabinClass)
        {
            _currency = currency;
            _cabinClass = cabinClass;

            _client.BaseAddress = new Uri("http://api.jetabroad.com/FlightSearchV1/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<FlightItinerary>> Get(
            string from, string to,
            DateTime departDate)
        {
            var result = new List<FlightItinerary>(0);
            var requestObj = CreateRequest(from, to, departDate);
            var requestString = JsonConvert.SerializeObject(requestObj);
            var content = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<FlightItinerary>>(
                    await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        private RequestModel CreateRequest(
            string from, string to,
            DateTime departDate)
        {
            var model = new RequestModel()
            {
                Adults = 1,
                AffiliateCode = Settings.Default.AffiliateCode,
                CabinClass = _cabinClass,
                CurrencyCode = _currency,
                DepartDate = departDate.ToString("yyyy-MM-dd"),
                From = from,
                OneWayOrReturn = "OneWay",
                To = to
            };

            return model;
        }
    }
}
