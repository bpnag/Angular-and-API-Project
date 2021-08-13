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
    class AreCoordinatesformTriangleTest
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
        [Description("Validating coordinates form triangle by giving odd triangle coordinates")]
        public void CheckAreCoordinatesFormTriangle1()
        {
            //Arrange
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(10, 20);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(20, 20);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            bool isTrue= triangleCoordinates.AreCoordinatesformTriangle(getRCByCoordinates);

            //Assertion
            Assert.IsTrue(isTrue);
        }

        [Test]
        [Category("Negative")]
        public void CheckAreCoordinatesFormTriangle2()
        {
            //Arrange
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(20, 20);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(30, 30);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            bool isTrue = triangleCoordinates.AreCoordinatesformTriangle(getRCByCoordinates);

            //Assertion
            Assert.IsFalse(isTrue);
        }

        [Test]
        [Category("Negative")]
        public void CheckAreCoordinatesFormTriangle3()
        {
            //Arrange
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 5;
            getRCByCoordinates.Topcoordinates = new Coordinates(0, 0);
            getRCByCoordinates.Midcoordinates = new Coordinates(0, 0);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(0, 0);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            bool isTrue = triangleCoordinates.AreCoordinatesformTriangle(getRCByCoordinates);

            //Assertion
            Assert.IsFalse(isTrue);
        }

        [Test]
        [Category("Positive")]
        [Description("Validating coordinates form triangle by giving even triangle coordinates")]
        public void CheckAreCoordinatesFormTriangle4()
        {
            //Arrange
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(20, 30);
            getRCByCoordinates.Midcoordinates = new Coordinates(30, 30);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(30, 40);

            //Action
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);
            bool isTrue = triangleCoordinates.AreCoordinatesformTriangle(getRCByCoordinates);

            //Assertion
            Assert.IsTrue(isTrue);
        }


        [Test]
        [Category("Negative")]
        [Description("Checking Null Arguement Exception")]
        public void CheckNullExceptionForForAreCoordinatesFormTriangle()
        {
            //Arrange
            GetRCByCoordinates getRCByCoordinates = null;
            ITriangle triangleCoordinates = new TriangleRepository(mockBlockCoordinates.Object, mockTriangleCoordinates.Object);

            //Assertion
            Assert.Throws<ArgumentNullException>(() => triangleCoordinates.AreCoordinatesformTriangle(getRCByCoordinates));
        }
    }
}
