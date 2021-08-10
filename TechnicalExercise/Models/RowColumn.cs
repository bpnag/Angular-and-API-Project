using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Models
{
    public class RowColumn
    {
        public char Row { get; set; }
        public int Column { get; set; }
        public RowColumn(char row,int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}