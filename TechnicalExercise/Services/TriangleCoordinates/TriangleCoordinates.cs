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
        #region To calculate even triangle co-ordinates
        public IEnumerable<Coordinates> CalculateEvenTriangleCoordinates(IBlock block)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            if (block != null)
            {
                coordinates.Add(block.TopLeftCoordinates);
                coordinates.Add(block.TopRightCoordinates);
                coordinates.Add(block.BottomRightCoordinates);
            }
            return coordinates;
        }
        #endregion To calculate even triangle co-ordinates

        #region To calculate odd triangle co-ordinates
        public IEnumerable<Coordinates> CalculateOddTriangleCoordinates(IBlock block)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            if (block != null)
            {
                coordinates.Add(block.TopLeftCoordinates);
                coordinates.Add(block.BottomLeftCoordinates);
                coordinates.Add(block.BottomRightCoordinates);
            }
            return coordinates;
        }
        #endregion To calculate odd triangle co-ordinates
    }
}