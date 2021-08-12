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
        public void B3OddTriangle()
        {
            var _block = new Mock<IBlock>();

            //Setup
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates=(List<Coordinates>)triangleCoordinates.CalculateOddTriangleCoordinates(_block.Object);

            //Assertion
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
        [Description("Odd Triangle at B:4")]
        public void B4EvenTriangle()
        {
            var _block = new Mock<IBlock>();

            //Setup
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(10, 10));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(10, 20));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(20, 20));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(20, 10));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateEvenTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(10, coordinates[0].X);
            Assert.AreEqual(10, coordinates[0].Y);
            Assert.AreEqual(20, coordinates[1].X);
            Assert.AreEqual(10, coordinates[1].Y);
            Assert.AreEqual(20, coordinates[2].X);
            Assert.AreEqual(20, coordinates[2].Y);
        }

        [Test]
        [Category("Positive")]
        [Description("Even Triangle at E:10")]
        public void E10EvenTriangle()
        {
            var _block = new Mock<IBlock>();

            //Setup
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(40, 40));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(40, 50));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(50, 50));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(50, 40));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateEvenTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(40, coordinates[0].X);
            Assert.AreEqual(40, coordinates[0].Y);
            Assert.AreEqual(50, coordinates[1].X);
            Assert.AreEqual(40, coordinates[1].Y);
            Assert.AreEqual(50, coordinates[2].X);
            Assert.AreEqual(50, coordinates[2].Y);
        }

        [Test]
        [Category("Positive")]
        [Description("Odd Triangle at F:5")]
        public void F5OddTriangle()
        {
            var _block = new Mock<IBlock>();

            //Setup
            _block.Setup(a => a.TopLeftCoordinates).Returns(() => new Coordinates(20, 50));
            _block.Setup(a => a.BottomLeftCoordinates).Returns(() => new Coordinates(20, 60));
            _block.Setup(a => a.BottomRightCoordinates).Returns(() => new Coordinates(30, 60));
            _block.Setup(a => a.TopRightCoordinates).Returns(() => new Coordinates(30, 50));

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateOddTriangleCoordinates(_block.Object);

            //Assertion
            Assert.AreEqual(3, coordinates.Count);
            Assert.AreEqual(20, coordinates[0].X);
            Assert.AreEqual(50, coordinates[0].Y);
            Assert.AreEqual(20, coordinates[1].X);
            Assert.AreEqual(60, coordinates[1].Y);
            Assert.AreEqual(30, coordinates[2].X);
            Assert.AreEqual(60, coordinates[2].Y);
        }

        [Test]
        [Category("Negative")]
        [Description("Odd Triangle at Null reference")]
        public void NullOddTriangle()
        {

            //Setup
            IBlock nullBlock = null;

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateOddTriangleCoordinates(nullBlock);

            //Assertion
            Assert.AreEqual(0, coordinates.Count);
        }

        [Test]
        [Category("Negative")]
        [Description("Even Triangle at Null reference")]
        public void NullEvenTriangle()
        {

            //Setup
            IBlock nullBlock = null;

            //Action
            ITriangleCoordinates triangleCoordinates = new TriangleCoordinates();
            List<Coordinates> coordinates = (List<Coordinates>)triangleCoordinates.CalculateEvenTriangleCoordinates(nullBlock);

            //Assertion
            Assert.AreEqual(0, coordinates.Count);
        }
    }
}
