using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundClassLiberary.Airport
{
    public class NavPoint
    {
        public string Name { get; private set; }
        public Coordinate Coordinate { get; set; }
        public string Code { get; private set; }
    }
}
