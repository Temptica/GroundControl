using System;
using System.Collections.Generic;
using System.Text;
using GroundClassLiberary.Vehicles;

namespace GroundClassLiberary
{
    public class Destination
    {
        public string ICAO { get; set; }
        public List<Aircraft> AircraftsFlying { get; set; }
    }
}
