using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightRouteAPI.Application.Interfaces;
using FlightRouteAPI.Core.Entities;

namespace FlightRouteAPI.Application.Services
{
    public class RouteService : IRouteService
    {
        public async Task<Journey> CalculateRoute(string origin, string destination, List<Flight> flights)
        {
            var journey = new Journey { Origin = origin, Destination = destination };
            string currentStation = origin;
            decimal totalPrice = 0;

 
            while (currentStation != destination)
            {
               
                var flight = flights.FirstOrDefault(f => f.DepartureStation == currentStation);

                if (flight == null)
                {
                    throw new Exception($"No se encontró una ruta válida desde {origin} hasta {destination}");
                }

                journey.Flights.Add(flight);
                totalPrice += flight.Price;
                currentStation = flight.ArrivalStation;
            }

            journey.Price = totalPrice;

            
            var returnFlights = new List<Flight>();
            currentStation = destination;
            decimal returnPrice = 0;

            while (currentStation != origin)
            {
                var returnFlight = flights.FirstOrDefault(f => f.DepartureStation == currentStation && f.ArrivalStation == origin);

                if (returnFlight == null) break;

                returnFlights.Add(returnFlight);
                returnPrice += returnFlight.Price;
                currentStation = returnFlight.ArrivalStation;
            }

            //vuelos de retorno
            if (returnFlights.Count > 0)
            {
                journey.ReturnFlights = returnFlights;
                journey.Price += returnPrice;
            }

            return journey;
        }
    }
}
