using TechnicalExercise.Models;
using TechnicalExercise.Services.BlockCoordinates;
using TechnicalExercise.Services.TriangleCoordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalExercise.Repos.Triangle
{
    public class TriangleRepository : ITriangle
    {
        private readonly IBlockCoordinates Block;
        private readonly ITriangleCoordinates TriangleCoordinates;
        public TriangleRepository(IBlockCoordinates block,ITriangleCoordinates triangleCoordinates)
        {
            this.Block = block;
            this.TriangleCoordinates = triangleCoordinates;
        }

        #region To fetch co-ordinates by given row and column
        public IEnumerable<Coordinates> FetchCoordinatesByRC(CreateTriangleByRC createTriangleByRC)
        {
            try
            {
                IEnumerable<Coordinates> coordinates = new List<Coordinates>();
                IBlock blockCo = new Block();
                if (createTriangleByRC != null && createTriangleByRC.Rowcolumn != null)
                {
                    blockCo = this.Block.GetBlockCoordinates(createTriangleByRC);
                    if (createTriangleByRC.Rowcolumn.Column % 2 == 0)
                    {
                        coordinates = this.TriangleCoordinates.CalculateEvenTriangleCoordinates(blockCo);
                    }
                    else {
                        coordinates = this.TriangleCoordinates.CalculateOddTriangleCoordinates(blockCo);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
                return coordinates;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion To fetch co-ordinates by given row and column

        #region To fetch row and column by given co-ordinates
        public RowColumn FetchRCByCoordinates(GetRCByCoordinates getRCByCoordinates)
        {
            try
            {
                if (getRCByCoordinates != null)
                {
                    Coordinates topCo = getRCByCoordinates.Topcoordinates;
                    Coordinates midCo = getRCByCoordinates.Midcoordinates;
                    Coordinates bottomCo = getRCByCoordinates.Bottomcoordinates;

                    int row = midCo.Y / getRCByCoordinates.CellSize;
                    if (topCo.Y == midCo.Y)
                    {
                        row++;
                    }
                    int column = (midCo.X / getRCByCoordinates.CellSize) * 2;
                    if (topCo.X == midCo.X)
                    {
                        column++;
                    }
                    return new RowColumn((char)(row + 64), column);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion To fetch row and column by given co-ordinates

        #region To check given co-ordinates form triangle
        public bool AreCoordinatesformTriangle(GetRCByCoordinates getRCByCoordinates)
        {
            try
            {
                if (getRCByCoordinates != null)
                {
                    Coordinates topCo = getRCByCoordinates.Topcoordinates;
                    Coordinates midCo = getRCByCoordinates.Midcoordinates;
                    Coordinates bottomCo = getRCByCoordinates.Bottomcoordinates;

                    double length1, length2;
                    if ((midCo.X == topCo.X && midCo.Y == bottomCo.Y) || (midCo.X == bottomCo.X && midCo.Y == topCo.Y))
                    {
                        length1 = Math.Sqrt(Math.Pow(midCo.X - topCo.X, 2) + Math.Pow(midCo.Y - topCo.Y, 2));
                        length2 = Math.Sqrt(Math.Pow(bottomCo.X - midCo.X, 2) + Math.Pow(bottomCo.Y - midCo.Y, 2));
                        if (length1 == getRCByCoordinates.CellSize && length2 == getRCByCoordinates.CellSize)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion To check given co-ordinates form triangle
    }
}