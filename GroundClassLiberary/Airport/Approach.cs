using System;
using System.Collections.Generic;

namespace GroundClassLiberary.Airport
{
    public class Approach
    {
        public string Name { get; set; }
        public string Runway { get; set; }        
        public List<NavPoint> ApproachRoute { get; set; }
    }
}
