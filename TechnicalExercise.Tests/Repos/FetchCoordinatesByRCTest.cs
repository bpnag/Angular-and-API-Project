using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Models;
using TechnicalExercise.Repos.Triangle;
using TechnicalExercise.Services.BlockCoordinates;
using TechnicalExercise.Services.TriangleCoordinates;

namespace TechnicalExercise.Tests.Repos
{
    [TestFixture]
    class FetchCoordinatesByRCTest
    {
        private Mock<IBlock> mockBlock;
        private Mock<IBlockCoordinates> mockBlockCoordinates;
        private Mock<ITriangleCoordinates> mockTriangleCoordinates;
        private Mock<ITriangleCoordinates> mockOdd;

        [SetUp]
        public void Initialize()
        {
            mockBlock = new Mock<IBlock>();
            mockBlockCoordinates = new Mock<IBlockCoordinates>();
            mockTriangleCoordinates = new Mock<ITriangleCoordinates>();

            mockBlock.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            mockBlock.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            mockBlock.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            mockBlock.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));
        }

        [Test]
        [Category("Positive")]
        [Description("Validating triangle coordinates by giving odd column")]
        public void CheckOddTriangleRepo()
        {
            //Arrange
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = 10, Rowcolumn = new RowColumn('B', 3) };
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(10, 20));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(It.IsAny<CreateTriangleByRC>())).Returns(mockBlock.Object);
            mockTriangleCoordinates.Setup(a => a.CalculateOddTriangleCoordinates(It.IsAny<IBlock>())).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockTriangleCoordinates.Verify(a => a.CalculateEvenTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(3, coordinates.Count);
            for (int i = 0; i < coordinates.Count; i++)
            {
                Assert.AreEqual(_list[i].X, coordinates[i].X);
                Assert.AreEqual(_list[i].Y, coordinates[i].Y);
            }

        }

        [Test]
        [Category("Positive")]
        [Description("Validating triangle coordinates by giving even column")]
        public void CheckEvenTriangleRepo()
        {
            //Arrange
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = 10, Rowcolumn = new RowColumn('B', 4) };
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(20, 10));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(It.IsAny<CreateTriangleByRC>())).Returns(mockBlock.Object);
            mockTriangleCoordinates.Setup(a => a.CalculateEvenTriangleCoordinates(It.IsAny<IBlock>())).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockTriangleCoordinates.Verify(a => a.CalculateOddTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(3, coordinates.Count);
            for(int i = 0; i < coordinates.Count; i++)
            {
                Assert.AreEqual(_list[i].X, coordinates[i].X);
                Assert.AreEqual(_list[i].Y, coordinates[i].Y);
            }
        }

        [Test]
        [Category("Negative")]
        [Description("Checking Null Arguement Exception")]
        public void CheckNullExceptionForFetchCoordinatesByRCMethod()
        {
            //Arrange
            CreateTriangleByRC createTriangleByRC = null; ;
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);

            //Assertion
            mockBlockCoordinates.Verify(a => a.GetBlockCoordinates(It.IsAny<CreateTriangleByRC>()), Times.Never);
            mockTriangleCoordinates.Verify(a => a.CalculateOddTriangleCoordinates(It.IsAny<Block>()), Times.Never);
            mockTriangleCoordinates.Verify(a => a.CalculateEvenTriangleCoordinates(It.IsAny<Block>()), Times.Never);
            Assert.Throws<ArgumentNullException>(() => triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC));
        }

    }
}
