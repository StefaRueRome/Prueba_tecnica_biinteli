using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRouteAPI.Core.Entities
{
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Flight> ReturnFlights { get; set; } = new List<Flight>();
    }
}
