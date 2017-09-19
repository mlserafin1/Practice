using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesAPIController : ApiController
    {
        [Route("api/sales/search")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage Search(string textBox, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
        {
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();

            var parameters = new VehicleSearchParameters()
            {
                TextBoxTerm = textBox,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MinYear = minYear,
                MaxYear = maxYear
            };

            var data = repo.SearchAllAvailableVehicles(parameters);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
