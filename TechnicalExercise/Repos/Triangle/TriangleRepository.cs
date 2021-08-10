﻿using TechnicalExercise.Models;
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
                return coordinates;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public RowColumn FetchRCByCoordinates(GetRCByCoordinates getRCByCoordinates)
        {
            try
            {
                Coordinates topCo = getRCByCoordinates.Topcoordinates;
                Coordinates midCo = getRCByCoordinates.Midcoordinates;
                Coordinates bottomCo = getRCByCoordinates.Bottomcoordinates;

                int row = midCo.Y / getRCByCoordinates.CellSize;
                if (topCo.Y == midCo.Y)
                {
                    row++;
                }
                int column = (midCo.X / getRCByCoordinates.CellSize)*2;
                if (topCo.X == midCo.X)
                {
                    column++;
                }
                return new RowColumn((char)(row + 64), column);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}