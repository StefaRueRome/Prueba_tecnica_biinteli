using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRouteAPI.Core.Entities
{
    public class Flight
    {
        public string DepartureStation { get; set; } 
        public string ArrivalStation { get; set; }   
        public decimal Price { get; set; }        
        public Transport Transport { get; set; }
    }

    
}
