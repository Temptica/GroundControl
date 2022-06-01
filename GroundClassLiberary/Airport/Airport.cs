using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundClassLiberary.Airport
{
    public class Airport //create constructors
    {        
        public string Name { get; set; }
        public string ICAO { get; set; }
        public int Height { get;  set; }
        public Coordinate Coordinate { get;  set; }        
        public List<Runway> Runways { get; set; }
        public List<Taxiway> Taxiways { get; set; }
        public List<Apron> Aprons { get; set; }
        public List<Approach> Approaches { get; set; }
        public List<Polygon> Polygons { get; set; }
#nullable enable
        public List<SID>? SIDs { get; set; }

        



    }
}
