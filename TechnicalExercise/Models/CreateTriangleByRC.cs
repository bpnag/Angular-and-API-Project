using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class CreateTriangleByRC
    {
        [Required]
        [Range(1,10)]
        public int CellSize { get; set; }

        [Required]
        public RowColumn Rowcolumn { get; set; }
    }
}