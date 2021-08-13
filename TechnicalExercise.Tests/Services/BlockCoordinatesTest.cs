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
        [Description("Validating Top left Coordinates of Block")]
        public void CheckTopLeftCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Arrange
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
        [Category("Positive")]
        [TestCase(10, 'C', 5, 30, 20)]
        [TestCase(5, 'B', 6, 15, 5)]
        [Description("Validating Top Right Coordinates of Block")]
        public void CheckTopRightCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Arrange
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
        [Category("Positive")]
        [TestCase(10, 'D', 7, 30, 40)]
        [TestCase(5, 'F', 8, 15, 30)]
        [Description("Validating Bottom Left Coordinates of Block")]
        public void CheckBottomLeftCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Arrange
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
        [Category("Positive")]
        [TestCase(10, 'D', 7, 40, 40)]
        [TestCase(5, 'F', 8, 20, 30)]
        [Description("Validating Bottom Right Coordinates of Block")]
        public void CheckBottomRightCoordinateofBlock(int cellSize, char row, int column, int expectedX, int expectedY)
        {
            //Arrange
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
        [Description("Checking Null Argument Exception")]
        public void CheckNullExceptionForBlockCoordinates()
        {
            //Arrange
            CreateTriangleByRC createTriangleByRC = null;
            IBlockCoordinates blockCo = new BlockCoordinates();

            //Assertion
            Assert.Throws<ArgumentNullException>(() => blockCo.GetBlockCoordinates(createTriangleByRC));
        }
    }
}
