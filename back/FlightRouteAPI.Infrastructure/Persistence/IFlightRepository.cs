using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Core.Entities;

namespace FlightRouteAPI.Infrastructure.Persistence
{
    public interface IFlightRepository
    {
        Task<Journey> GetJourneyAsync(string origin, string destination);
        Task SaveJourneyAsync(Journey journey);
    }
}
