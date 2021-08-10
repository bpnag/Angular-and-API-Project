using TechnicalExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalExercise.Services.BlockCoordinates
{
    public interface IBlockCoordinates
    {
        IBlock GetBlockCoordinates(CreateTriangleByRC createTriangleByRC);
    }
}
