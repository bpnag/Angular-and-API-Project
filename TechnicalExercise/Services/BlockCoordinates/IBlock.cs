using TechnicalExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalExercise.Services.BlockCoordinates
{
    public interface IBlock
    {
        Coordinates TopLeftCoordinates { get; set; }
        Coordinates BottomLeftCoordinates { get; set; }
        Coordinates BottomRightCoordinates { get; set; }
        Coordinates TopRightCoordinates { get; set; }
    }
}
