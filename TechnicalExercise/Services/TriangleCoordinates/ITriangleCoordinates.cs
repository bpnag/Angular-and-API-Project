using TechnicalExercise.Models;
using TechnicalExercise.Services.BlockCoordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalExercise.Services.TriangleCoordinates
{
    public interface ITriangleCoordinates
    {
        IEnumerable<Coordinates> CalculateOddTriangleCoordinates(IBlock block);
        IEnumerable<Coordinates> CalculateEvenTriangleCoordinates(IBlock block);
    }
}
