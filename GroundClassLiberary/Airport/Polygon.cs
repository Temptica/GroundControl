using GroundClassLiberary.Airport;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundClassLiberary.Airport
{
    public class Polygon
    {
        public string Name { get; set; }        
        public List<Coordinate> BoundCoordinates { get; set; }
        public string Color { get; set; }
    }
}
