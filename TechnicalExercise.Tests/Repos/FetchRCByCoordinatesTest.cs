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
    class FetchRCByCoordinatesTest
    {
        private Mock<IBlock> mockBlock;
        private Mock<IBlockCoordinates> mockBlockCoordinates;
        private Mock<ITriangleCoordinates> mockTriangleCoordinates;

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
        public void CheckFetchRC1()
        {
            //Setup
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates=new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(10, 20);
            getRCByCoordinates.Bottomcoordinates=new Coordinates(20, 20);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            RowColumn rowColumn = triangleCoordinates.FetchRCByCoordinates(getRCByCoordinates);

            //Assertion
            Assert.AreEqual('B', rowColumn.Row);
            Assert.AreEqual(3, rowColumn.Column);
        }

        [Test]
        [Category("Positive")]
        public void CheckFetchRC2()
        {
            //Setup
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(20, 10);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(20, 20);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            RowColumn rowColumn = triangleCoordinates.FetchRCByCoordinates(getRCByCoordinates);

            //Assertion
            Assert.AreEqual('B', rowColumn.Row);
            Assert.AreEqual(4, rowColumn.Column);
        }
    }
}
