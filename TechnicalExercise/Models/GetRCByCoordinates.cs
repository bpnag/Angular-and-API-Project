using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class GetRCByCoordinates
    {
        public int CellSize { get;set; }
        public Coordinates Topcoordinates { get; set; }
        public Coordinates Midcoordinates { get; set; }
        public Coordinates Bottomcoordinates { get; set; }
    }
}