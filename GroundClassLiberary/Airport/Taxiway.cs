using System;
using System.Collections.Generic;
using System.Text;

namespace GroundClassLiberary.Airport
{
    public class Taxiway
    {
        public string Name { get; set; }
        public List<Coordinate> Border { get; set; }
        public List<List<Coordinate>> TaxiwayLines { get; set; }
#nullable enable
        public List<Coordinate>? StopBar { get; set; }
    }
}
