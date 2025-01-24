using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Core.Entities;

namespace FlightRouteAPI.Application.Interfaces
{
    public interface IFlightService
    {
        Task<List<Flight>> GetFlightsAsync(string apiUrl);
    }
}
