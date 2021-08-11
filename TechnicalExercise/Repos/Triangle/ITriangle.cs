using TechnicalExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalExercise.Repos.Triangle
{
    public interface ITriangle
    {
        IEnumerable<Coordinates> FetchCoordinatesByRC(CreateTriangleByRC createTriangleByRC);
        RowColumn FetchRCByCoordinates(GetRCByCoordinates getRCByCoordinates);
        bool AreCoordinatesformTriangle(GetRCByCoordinates getRCByCoordinates);
    }
}
