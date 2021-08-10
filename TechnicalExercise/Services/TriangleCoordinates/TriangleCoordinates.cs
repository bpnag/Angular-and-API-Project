using TechnicalExercise.Models;
using TechnicalExercise.Services.BlockCoordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Services.TriangleCoordinates
{
    public class TriangleCoordinates : ITriangleCoordinates
    {
        public IEnumerable<Coordinates> CalculateEvenTriangleCoordinates(IBlock block)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            coordinates.Add(block.TopLeftCoordinates);
            coordinates.Add(block.TopRightCoordinates);
            coordinates.Add(block.BottomRightCoordinates);
            return coordinates;
        }

        public IEnumerable<Coordinates> CalculateOddTriangleCoordinates(IBlock block)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            coordinates.Add(block.TopLeftCoordinates);
            coordinates.Add(block.BottomLeftCoordinates);
            coordinates.Add(block.BottomRightCoordinates);
            return coordinates;
        }
    }
}