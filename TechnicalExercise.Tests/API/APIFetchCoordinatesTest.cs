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
    class APIFetchCoordinatesTest
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
        public void CheckFetchCoordinatesAPI1()
        {
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC();
            createTriangleByRC.CellSize = 10;
            createTriangleByRC.Rowcolumn = new RowColumn('D', 12);

            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new Coordinates(50, 30));
            _list.Add(new Coordinates(50, 40));
            _list.Add(new Coordinates(60, 40));

            mockTriangleRepo.Setup(a => a.AreCoordinatesformTriangle(It.IsAny<GetRCByCoordinates>())).Returns(true);
            mockTriangleRepo.Setup(a => a.FetchCoordinatesByRC(It.IsAny<CreateTriangleByRC>())).Returns(_list);

            triangleController.Validate(createTriangleByRC);
            var response = triangleController.FetchCoordinatesByRC(createTriangleByRC);

            var data = response.Content.ReadAsStringAsync().Result;
            var contnetList = JsonConvert.DeserializeObject<List<Coordinates>>(data);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(3, contnetList.Count);
        }

        [Test]
        [Category("Negative")]
        public void CheckFetchCoordinatesAPI2()
        {
            CreateTriangleByRC createTriangleByRC = new CreateTriangleByRC();
            createTriangleByRC.CellSize = 10;
            createTriangleByRC.Rowcolumn = new RowColumn();
            createTriangleByRC.Rowcolumn.Row = 'B';
            createTriangleByRC.Rowcolumn.Column=0;

            triangleController.Validate(createTriangleByRC);
            var response = triangleController.FetchCoordinatesByRC(createTriangleByRC);

            var data = response.Content.ReadAsStringAsync().Result;
            ErrorMessage error = JsonConvert.DeserializeObject<ErrorMessage>(data);

            mockTriangleRepo.Verify(a => a.FetchCoordinatesByRC(It.IsAny<CreateTriangleByRC>()), Times.Never);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual("Invalid Input", error.Message);
        }

        [Test]
        [Category("Negative")]
        public void CheckFetchCoordinatesAPI3()
        {
            CreateTriangleByRC createTriangleByRC = null;

            triangleController.Validate(createTriangleByRC);
            var response = triangleController.FetchCoordinatesByRC(createTriangleByRC);

            var data = response.Content.ReadAsStringAsync().Result;
            ErrorMessage error = JsonConvert.DeserializeObject<ErrorMessage>(data);

            mockTriangleRepo.Verify(a => a.FetchCoordinatesByRC(It.IsAny<CreateTriangleByRC>()), Times.Never);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreEqual("Invalid Input", error.Message);
        }
    }
}
