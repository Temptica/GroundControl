using GroundClassLiberary.Airport;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundClassLiberary.Airport.NavPoints
{
    public class GPS: NavPoint
    {
        public int MinHeight { get; set; }
        public int MaxHeight { get; set; }
        public int FixedHeight { get; set; }
    }
}
