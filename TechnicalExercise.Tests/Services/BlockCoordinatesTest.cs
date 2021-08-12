using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Models;
using TechnicalExercise.Services.BlockCoordinates;

namespace TechnicalExercise.Tests.Services
{
    [TestFixture]
    class BlockCoordinatesTest
    {
        [Test]
        [Category("Positive")]
        [TestCase(10, 'C', 5, 20, 20)]
        [TestCase(5, 'B', 6, 10, 5)]
        public void CheckTopLeftCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreEqual(block.TopLeftCoordinates.X, expectedX);
            Assert.AreEqual(block.TopLeftCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Negative")]
        [TestCase(10, 'A', 2, 20, 20)]
        public void CheckTopLeftCoordinateofBlockNegative(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreNotEqual(block.TopLeftCoordinates.X, expectedX);
            Assert.AreNotEqual(block.TopLeftCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Positive")]
        [TestCase(10, 'C', 5, 30, 20)]
        [TestCase(5, 'B', 6, 15, 5)]
        public void CheckTopRightCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreEqual(block.TopRightCoordinates.X, expectedX);
            Assert.AreEqual(block.TopRightCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Negative")]
        [TestCase(10, 'F', 1, 30, 20)]
        public void CheckTopRightCoordinateofBlockNegative(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreNotEqual(block.TopRightCoordinates.X, expectedX);
            Assert.AreNotEqual(block.TopRightCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Positive")]
        [TestCase(10, 'D', 7, 30, 40)]
        [TestCase(5, 'F', 8, 15, 30)]
        public void CheckBottomLeftCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreEqual(block.BottomLeftCoordinates.X, expectedX);
            Assert.AreEqual(block.BottomLeftCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Negative")]
        [TestCase(5, 'F', 8, 50, 10)]
        public void CheckBottomLeftCoordinateofBlockNegative(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreNotEqual(block.BottomLeftCoordinates.X, expectedX);
            Assert.AreNotEqual(block.BottomLeftCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Positive")]
        [TestCase(10, 'D', 7, 40, 40)]
        [TestCase(5, 'F', 8, 20, 30)]
        public void CheckBottomRightCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreEqual(block.BottomRightCoordinates.X, expectedX);
            Assert.AreEqual(block.BottomRightCoordinates.Y, expectedY);
        }

        [Test]
        [Category("Negative")]
        [TestCase(5, 'F', 8, 15, 25)]
        public void CheckBottomRightCoordinateofBlockNegative(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Setup
            IBlockCoordinates blockCo = new BlockCoordinates();
            IBlock block = new Block();
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = cellSize, Rowcolumn = new RowColumn(row, column) };

            //Action
            block = blockCo.GetBlockCoordinates(createTriangleByRC);

            //Assertion
            Assert.AreNotEqual(block.BottomRightCoordinates.X, expectedX);
            Assert.AreNotEqual(block.BottomRightCoordinates.Y, expectedY);
        }
    }
}
