using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace GroundClassLiberary
{
    public class AirportPolygon
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public VertexPositionColor[] Vertices { get; set; }
        public int[] Indices { get; set; }
    }
}
