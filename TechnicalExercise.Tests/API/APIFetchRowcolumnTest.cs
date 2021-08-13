using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using TechnicalExercise.Controllers;
using TechnicalExercise.Models;
using TechnicalExercise.Repos.Triangle;

namespace TechnicalExercise.Tests.API
{
    [TestFixture]
    class APIFetchRowcolumnTest
    {
        private Mock<ITriangle> mockTriangleRepo;
        private TriangleController triangleController;


        [SetUp]
        public void Initialize()
        {
            mockTriangleRepo = new Mock<ITriangle>();
            triangleController = new TriangleController(mockTriangleRepo.Object);
            triangleController.Request = new System.Net.Http.HttpRequestMessage();
            triangleController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [Test]
        [Category("Positive")]
        public void CheckFetchRowColumnAPI1()
        {
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(10, 20);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(20, 20);

            mockTriangleRepo.Setup(a => a.AreCoordinatesformTriangle(It.IsAny<GetRCByCoordinates>())).Returns(true);
            mockTriangleRepo.Setup(a => a.FetchRCByCoordinates(It.IsAny<GetRCByCoordinates>())).Returns(new RowColumn('B', 4));

            triangleController.Validate(getRCByCoordinates);
            var response = triangleController.FetchRCByCoordinates(getRCByCoordinates);

            var data = response.Content.ReadAsStringAsync().Result;
            RowColumn rowColumn = JsonConvert.DeserializeObject<RowColumn>(data);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual('B', rowColumn.Row);
            Assert.AreEqual(4, rowColumn.Column);
        }

        [Test]
        [Category("Negative")]
        public void CheckFetchRowColumnAPI2()
        {
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 10;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(10, 20);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(20, 20);

            mockTriangleRepo.Setup(a => a.AreCoordinatesformTriangle(It.IsAny<GetRCByCoordinates>())).Returns(false);

            triangleController.Validate(getRCByCoordinates);
            var response = triangleController.FetchRCByCoordinates(getRCByCoordinates);

            var data = response.Content.ReadAsStringAsync().Result;
            ErrorMessage error = JsonConvert.DeserializeObject<ErrorMessage>(data);

            mockTriangleRepo.Verify(a => a.FetchRCByCoordinates(It.IsAny<GetRCByCoordinates>()), Times.Never);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual("Coordinates does not form Triangle", error.Message);
        }

        [Test]
        [Category("Negative")]
        public void CheckFetchRowColumnAPI3()
        {
            GetRCByCoordinates getRCByCoordinates = null;

            triangleController.Validate(getRCByCoordinates);
            var response = triangleController.FetchRCByCoordinates(getRCByCoordinates);

            var data = response.Content.ReadAsStringAsync().Result;
            ErrorMessage error = JsonConvert.DeserializeObject<ErrorMessage>(data);

            mockTriangleRepo.Verify(a => a.AreCoordinatesformTriangle(It.IsAny<GetRCByCoordinates>()), Times.Never);
            mockTriangleRepo.Verify(a => a.FetchRCByCoordinates(It.IsAny<GetRCByCoordinates>()), Times.Never);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual("Invalid Input", error.Message);
        }

        [Test]
        [Category("Negative")]
        public void CheckFetchRowColumnAPI4()
        {
            GetRCByCoordinates getRCByCoordinates = new GetRCByCoordinates();
            getRCByCoordinates.CellSize = 0;
            getRCByCoordinates.Topcoordinates = new Coordinates(10, 10);
            getRCByCoordinates.Midcoordinates = new Coordinates(10, 20);
            getRCByCoordinates.Bottomcoordinates = new Coordinates(20, 20);

            triangleController.Validate(getRCByCoordinates);
            var response = triangleController.FetchRCByCoordinates(getRCByCoordinates);

            var data = response.Content.ReadAsStringAsync().Result;
            ErrorMessage error = JsonConvert.DeserializeObject<ErrorMessage>(data);

            mockTriangleRepo.Verify(a => a.AreCoordinatesformTriangle(It.IsAny<GetRCByCoordinates>()), Times.Never);
            mockTriangleRepo.Verify(a => a.FetchRCByCoordinates(It.IsAny<GetRCByCoordinates>()), Times.Never);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual("Invalid Input", error.Message);
        }
    }
}
