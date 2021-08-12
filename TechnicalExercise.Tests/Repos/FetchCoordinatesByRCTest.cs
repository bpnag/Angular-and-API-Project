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
        private Mock<ITriangleCoordinates> mockEven;
        private Mock<ITriangleCoordinates> mockOdd;

        [SetUp]
        public void Initialize()
        {
            mockBlock = new Mock<IBlock>();
            mockBlockCoordinates = new Mock<IBlockCoordinates>();
            mockEven = new Mock<ITriangleCoordinates>();
            mockOdd = new Mock<ITriangleCoordinates>();

            mockBlock.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            mockBlock.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            mockBlock.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            mockBlock.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));
        }

        [Test]
        [Category("Positive")]
        public void CheckOddTriangleRepo()
        {
            //Setup
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = 10, Rowcolumn = new RowColumn('B', 3) };
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(10, 20));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(createTriangleByRC)).Returns(mockBlock.Object);
            mockEven.Setup(a => a.CalculateOddTriangleCoordinates(mockBlock.Object)).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockEven.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockEven.Verify(a => a.CalculateEvenTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(10, coordinates[0].X);
            Assert.AreEqual(10, coordinates[0].Y);
            Assert.AreEqual(10, coordinates[1].X);
            Assert.AreEqual(20, coordinates[1].Y);
            Assert.AreEqual(20, coordinates[2].X);
            Assert.AreEqual(20, coordinates[2].Y);

        }

        [Test]
        [Category("Positive")]
        public void CheckEvenTriangleRepo()
        {
            //Setup
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC { CellSize = 10, Rowcolumn = new RowColumn('B', 4) };
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(20, 10));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(createTriangleByRC)).Returns(mockBlock.Object);
            mockEven.Setup(a => a.CalculateEvenTriangleCoordinates(mockBlock.Object)).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockEven.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockEven.Verify(a => a.CalculateOddTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(10, coordinates[0].X);
            Assert.AreEqual(10, coordinates[0].Y);
            Assert.AreEqual(20, coordinates[1].X);
            Assert.AreEqual(10, coordinates[1].Y);
            Assert.AreEqual(20, coordinates[2].X);
            Assert.AreEqual(20, coordinates[2].Y);

        }

        [Test]
        [Category("Negative")]
        public void CheckOddTriangleRepoNegative()
        {
            //Setup
            CreateTriangleByRC createTriangleByRC = null; ;
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(10, 20));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(createTriangleByRC)).Returns(mockBlock.Object);
            mockEven.Setup(a => a.CalculateOddTriangleCoordinates(mockBlock.Object)).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockEven.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockEven.Verify(a => a.CalculateEvenTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(0, coordinates.Count);
        }

        [Test]
        [Category("Negative")]
        public void CheckEvenTriangleRepoNegative()
        {
            //Setup
            CreateTriangleByRC createTriangleByRC = null; ;
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(10, 10));
            _list.Add(new Coordinates(10, 20));
            _list.Add(new Coordinates(20, 20));

            mockBlockCoordinates.Setup(a => a.GetBlockCoordinates(createTriangleByRC)).Returns(mockBlock.Object);
            mockEven.Setup(a => a.CalculateEvenTriangleCoordinates(mockBlock.Object)).Returns(_list);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockEven.Object);
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.FetchCoordinatesByRC(createTriangleByRC);

            //Assertion
            mockEven.Verify(a => a.CalculateOddTriangleCoordinates(mockBlock.Object), Times.Never);
            Assert.AreEqual(0, coordinates.Count);
        }

    }
}
