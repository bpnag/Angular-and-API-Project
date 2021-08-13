using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class Coordinates
    {
        [Required]
        [Range(0,60)]
        public int X { get; set; }

        [Required]
        [Range(0, 60)]
        public int Y { get; set; }
        public Coordinates(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}