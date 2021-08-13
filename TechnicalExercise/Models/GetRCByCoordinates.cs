using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class GetRCByCoordinates
    {
        [Required]
        [Range(1,10)]
        public int CellSize { get;set; }
        [Required]
        public Coordinates Topcoordinates { get; set; }
        [Required]
        public Coordinates Midcoordinates { get; set; }
        [Required]
        public Coordinates Bottomcoordinates { get; set; }
    }
}