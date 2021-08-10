using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}