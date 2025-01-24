using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightRouteAPI.Infrastructure.Persistence
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DbApp _context;

        public FlightRepository(DbApp context)
        {
            _context = context;
        }

        public async Task<Journey> GetJourneyAsync(string origin, string destination)
        {
            return await _context.Journeys
                .Include(j => j.Flights)
                .FirstOrDefaultAsync(j => j.Origin == origin && j.Destination == destination);
        }

        public async Task SaveJourneyAsync(Journey journey)
        {
            _context.Journeys.Add(journey);
            await _context.SaveChangesAsync();
        }
    }
}
