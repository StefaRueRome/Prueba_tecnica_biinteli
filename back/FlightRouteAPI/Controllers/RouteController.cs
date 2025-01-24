using FlightRouteAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightRouteAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IFlightService _flightService;

        public RouteController(IRouteService routeService, IFlightService flightService)
        {
            _routeService = routeService;
            _flightService = flightService;
        }

        [HttpGet("flights")]
        public async Task<IActionResult> GetRoute([FromQuery] string origin, [FromQuery] string destination)
        {
            try
            {
                var flights = await _flightService.GetFlightsAsync("https://bitecingcom.ipage.com/testapi/avanzado.js");
                var route = await _routeService.CalculateRoute(origin, destination, flights);
                return Ok(route);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        } 
    }
}
