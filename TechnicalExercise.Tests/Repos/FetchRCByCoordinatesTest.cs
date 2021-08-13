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
        private Mock<IBlockCoordinates> mockBlockCoordinates;
        private Mock<ITriangleCoordinates> mockTriangleCoordinates;

        [SetUp]
        public void Initialize()
        {
            mockBlockCoordinates = new Mock<IBlockCoordinates>();
            mockTriangleCoordinates = new Mock<ITriangleCoordinates>();
        }

        [Test]
        [Category("Positive")]
        [Description("Validating row and column by giving even triangle coordinates as input")]
        public void CheckFetchRCByOddCoordinates()
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
        [Description("Validating row and column by giving odd triangle coordinates")]
        public void CheckFetchRCByEvenCoordinates()
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

        [Test]
        [Category("Negative")]
        [Description("Checking Null Arguement Exception")]
        public void CheckNullExceptionForFetchRCByCoordinates()
        {
            //Setup
            GetRCByCoordinates getRCByCoordinates = null;
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);

            //Assertion
            Assert.Throws<ArgumentNullException>(() => triangleCoordinates.FetchRCByCoordinates(getRCByCoordinates));
        }
    }
}
