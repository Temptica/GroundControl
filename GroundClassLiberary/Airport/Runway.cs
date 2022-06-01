using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundClassLiberary.Airport
{
    public class Runway
    {
        public string Designator { get; set; }
        public int Heading { get; set; }
        public string ReciprocalDesignator { get; set; }        
        public int ReciprocalHeading { get; set; }
        public int Length { get; set; }
        public List<Coordinate> RunwayPolygon { get; set; }

    }
}
