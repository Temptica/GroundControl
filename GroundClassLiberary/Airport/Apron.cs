using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GroundClassLiberary.Airport
{
    public class Apron
    {
        public Apron(string apronName, List<Stand> stands)
        {
            ApronName = apronName;
            Stands = stands;
        }

        public string ApronName { get; set; }
        public List<Stand> Stands { get; set; }
    }
}
