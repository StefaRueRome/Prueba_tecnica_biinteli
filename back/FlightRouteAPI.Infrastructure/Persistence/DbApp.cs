using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightRouteAPI.Infrastructure.Persistence
{
    public class DbApp: DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journeys { get; set; }

        public DbApp(DbContextOptions<DbApp> options) : base(options) { }
    }
}
