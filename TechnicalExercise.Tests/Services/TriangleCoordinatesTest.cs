using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Models;
using TechnicalExercise.Services.BlockCoordinates;
using TechnicalExercise.Services.TriangleCoordinates;

namespace TechnicalExercise.Tests.Services
{
    [TestFixture]
    class TriangleCoordinatesTest
    {
        [Test]
        [Category("Positive")]
        [Description("Odd Triangle at B:3")]
        public void CheckOddTriangleAtB3()
        {
            var _block = new Mock<IBlock>();

            //Arrange
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates=(List<Coordinates>)triangleCoordinates.CalculateOddTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.X, coordinates[0].X);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.Y, coordinates[0].Y);
            Assert.AreEqual(_block.Object.BottomLeftCoordinates.X, coordinates[1].X);
            Assert.AreEqual(_block.Object.BottomLeftCoordinates.Y, coordinates[1].Y);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.X, coordinates[2].X);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.Y, coordinates[2].Y);
        }

        [Test]
        [Category("Positive")]
        [Description("Even Triangle at B:4")]
        public void CheckEvenTriangleAtB4()
        {
            var _block = new Mock<IBlock>();

            //Arrange
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateEvenTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.X, coordinates[0].X);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.Y, coordinates[0].Y);
            Assert.AreEqual(_block.Object.TopRightCoordinates.X, coordinates[1].X);
            Assert.AreEqual(_block.Object.TopRightCoordinates.Y, coordinates[1].Y);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.X, coordinates[2].X);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.Y, coordinates[2].Y);
        }

        [Test]
        [Category("Positive")]
        [Description("Even Triangle at E:10")]
        public void CheckEvenTriangleAtE10()
        {
            var _block = new Mock<IBlock>();

            //Arrange
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(40, 40));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(40, 50));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(50, 50));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(50, 40));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateEvenTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.X, coordinates[0].X);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.Y, coordinates[0].Y);
            Assert.AreEqual(_block.Object.TopRightCoordinates.X, coordinates[1].X);
            Assert.AreEqual(_block.Object.TopRightCoordinates.Y, coordinates[1].Y);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.X, coordinates[2].X);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.Y, coordinates[2].Y);
        }

        [Test]
        [Category("Positive")]
        [Description("Odd Triangle at F:5")]
        public void CheckOddTriangleAtF5()
        {
            var _block = new Mock<IBlock>();

            //Arrange
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(20, 50));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(20, 60));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(30, 60));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(30, 50));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateOddTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.X, coordinates[0].X);
            Assert.AreEqual(_block.Object.TopLeftCoordinates.Y, coordinates[0].Y);
            Assert.AreEqual(_block.Object.BottomLeftCoordinates.X, coordinates[1].X);
            Assert.AreEqual(_block.Object.BottomLeftCoordinates.Y, coordinates[1].Y);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.X, coordinates[2].X);
            Assert.AreEqual(_block.Object.BottomRightCoordinates.Y, coordinates[2].Y);
        }

        [Test]
        [Category("Negative")]
        [Description("Checking Argument Null Exception for Odd Triangle")]
        public void CheckNullExceptionForOddTriangle()
        {

            //Arrange
            IBlock nullBlock = null;
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();

            //Assertion
            Assert.Throws<ArgumentNullException>(() => triangleCoordinates.CalculateOddTriangleCoordinates(nullBlock));
        }

        [Test]
        [Category("Negative")]
        [Description("Checking Argument Null Exception for Even Triangle")]
        public void CheckNullExceptionForEvenTriangle()
        {

            //Arrange
            IBlock nullBlock = null;
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();

            //Assertion
            Assert.Throws<ArgumentNullException>(() => triangleCoordinates.CalculateEvenTriangleCoordinates(nullBlock));
        }
    }
}
