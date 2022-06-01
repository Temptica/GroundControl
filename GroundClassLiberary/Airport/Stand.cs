using System;
using System.Collections.Generic;
using System.Text;

namespace GroundClassLiberary.Airport
{
    public class Stand
    {
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }
        public List<Coordinate> Taxiway { get; set; }
    }
}
