using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundClassLiberary.Airport
{
    public class Coordinate
    {
        private static int multiplier = 100;
        public float Lat { get; set; }
        public float Lon { get; set; }
        public Coordinate(float posX, float posY)
        {
            Lat = posX;
            Lon = posY;
        }
        public Vector2 ToVector2()
        {
            //return new Vector2(((float)Math.Round(coordinate.PosX,4)), ((float)Math.Round(coordinate.PosY,4)));
            return new Vector2((float)Lat * multiplier, (float)Lon * multiplier);
        }
        public static Vector2 ConvertToVector2(Coordinate coordinate)
        {
            //return new Vector2(((float)Math.Round(coordinate.PosX,4)), ((float)Math.Round(coordinate.PosY,4)));
            return new Vector2((float)coordinate.Lat * multiplier, (float)coordinate.Lon * multiplier);
        }
        public static List<Vector2> ConvertToVectors2List(List<Coordinate> coordinates)
        {
            var vector2 = new List<Vector2>();
            foreach (var coord in coordinates)
            {
                vector2.Add(ConvertToVector2(coord));
            }
            return vector2;
        }
    }
}
