﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRouteAPI.Core.Entities
{
    public class Transport
    {
        public string FlightCarrier { get; set; } // Aerolínea o transportista del vuelo.
        public string FlightNumber { get; set; }
    }
}
