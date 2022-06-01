using System;
using System.Collections.Generic;
using System.Text;

namespace GroundClassLiberary.Vehicles
{
    class Airliner
    {
        public string Name { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Aircraft> Aircrafts { get; set; }
    }
}
