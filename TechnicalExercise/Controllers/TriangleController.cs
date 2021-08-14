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

        #region API controller to fetch co-ordinates by given row and column
        [Route("api/FetchCoordinates")]
        [HttpPost]
        public HttpResponseMessage FetchCoordinatesByRC([FromBody] CreateTriangleByRC createTriangleByRC)
        {
            try
            {
                IEnumerable<Coordinates> coordinates = new List<Coordinates>();
                if (ModelState.IsValid && createTriangleByRC!=null)
                {
                    coordinates = this.Triangle.FetchCoordinatesByRC(createTriangleByRC);
                    return Request.CreateResponse(HttpStatusCode.OK, coordinates);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Input");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }
        }
        #endregion API controller to fetch co-ordinates by given row and column

        #region API controller to fetch row and column by given co-ordinates
        [Route("api/FetchRowAndColumn")]
        [HttpPost]
        public HttpResponseMessage FetchRCByCoordinates([FromBody] GetRCByCoordinates getRCByCoordinates)
        {
            try
            {
                if (ModelState.IsValid && getRCByCoordinates != null)
                {
                    //To check whether coordinates form triangle or not
                    if (this.Triangle.AreCoordinatesformTriangle(getRCByCoordinates))
                    {
                        var rowColumn = this.Triangle.FetchRCByCoordinates(getRCByCoordinates);
                        return Request.CreateResponse(HttpStatusCode.OK, rowColumn);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Coordinates does not form triangle w.r.t given layout");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Input");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);

            }
        }
        #endregion API controller to fetch row and column by given co-ordinates
    }
}