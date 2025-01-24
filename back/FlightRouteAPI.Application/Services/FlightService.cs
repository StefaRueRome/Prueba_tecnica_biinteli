using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Application.Interfaces;
using FlightRouteAPI.Core.Entities;
using Newtonsoft.Json;

namespace FlightRouteAPI.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;

        public FlightService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Flight>> GetFlightsAsync(string apiUrl)
        {
            var response = await _httpClient.GetStringAsync(apiUrl);
            return JsonConvert.DeserializeObject<List<Flight>>(response);
        }

    }
}
