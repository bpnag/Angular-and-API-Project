using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechnicalExercise.Models;
using TechnicalExercise.Repos.Triangle;

namespace TechnicalExercise.Controllers
{
    public class TriangleController : ApiController
    {
        private readonly ITriangle Triangle;
        public TriangleController(ITriangle triangle)
        {
            this.Triangle = triangle;
        }
        [Route("api/FetchCoordinates")]
        [HttpPost]
        public HttpResponseMessage FetchCoordinatesByRC([FromBody] CreateTriangleByRC createTriangleByRC)
        {
            try
            {
                IEnumerable<Coordinates> coordinates = new List<Coordinates>();
                if (createTriangleByRC != null)
                {
                    coordinates = this.Triangle.FetchCoordinatesByRC(createTriangleByRC);
                    return Request.CreateResponse(HttpStatusCode.OK, coordinates);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error sorry!!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }
        }

        [Route("api/FetchRowAndColumn")]
        [HttpPost]
        public HttpResponseMessage FetchRCByCoordinates([FromBody] GetRCByCoordinates getRCByCoordinates)
        {
            try
            {
                if (getRCByCoordinates != null)
                {
                    if (this.Triangle.AreCoordinatesformTriangle(getRCByCoordinates))
                    {
                        var rowColumn = this.Triangle.FetchRCByCoordinates(getRCByCoordinates);
                        return Request.CreateResponse(HttpStatusCode.OK, rowColumn);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Coordinates does not form Triangle");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error sorry!!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);

            }
        }
    }
}