using TechnicalExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Services.BlockCoordinates
{
    public class BlockCoordinates : IBlockCoordinates
    {
        public IBlock GetBlockCoordinates(CreateTriangleByRC createTriangleByRC)
        {
            try
            {
                IBlock block = new Block();
                int row, column;
                if (createTriangleByRC != null && createTriangleByRC.Rowcolumn != null)
                {
                    row = createTriangleByRC.Rowcolumn.Row - 64;
                    column = createTriangleByRC.Rowcolumn.Column / 2;
                    if (!(createTriangleByRC.Rowcolumn.Column % 2 == 0))
                    {
                        column++;
                    }
                    block = new Block(row,column, createTriangleByRC.CellSize);
                }
                return block;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}