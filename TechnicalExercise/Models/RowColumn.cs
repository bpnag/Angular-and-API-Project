using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class RowColumn
    {
        [Range('A','F',ErrorMessage = "Row must be between A to F")]
        public char Row { get; set; }
        [Range(1, 12)]
        public int Column { get; set; }

        public RowColumn()
        {

        }
        public RowColumn(char row,int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}