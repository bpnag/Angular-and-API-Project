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
        public void OddTriangle()
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
        public void EvenTriangle()
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
    }
}
