using TechnicalExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Services.BlockCoordinates
{
    public class Block : IBlock
    {
        public Coordinates TopLeftCoordinates { get; set; }
        public Coordinates BottomLeftCoordinates { get; set; }
        public Coordinates BottomRightCoordinates { get; set; }
        public Coordinates TopRightCoordinates { get; set; }

        public Block()
        {

        }
        public Block(int row,int column,int cellSize)
        {
            this.TopLeftCoordinates = new Coordinates((column - 1) * cellSize, (row - 1) * cellSize);
            this.BottomLeftCoordinates = new Coordinates((column - 1) * cellSize, (row) * cellSize);
            this.BottomRightCoordinates = new Coordinates((column) * cellSize, (row) * cellSize);
            this.TopRightCoordinates = new Coordinates((column) * cellSize, (row - 1) * cellSize);
        }
    }
}