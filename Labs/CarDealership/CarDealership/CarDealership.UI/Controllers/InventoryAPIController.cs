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
    [AllowAnonymous]
    public class InventoryAPIController : ApiController
    {
        [Route("api/inventory/usedsearch")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage UsedSearch(string textBox, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
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

            var data = repo.SearchUsedAvailableVehicles(parameters);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/inventory/newsearch")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage NewSearch(string textBox, decimal? minPrice, decimal? maxPrice, string minYear, string maxYear)
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

            var data = repo.SearchNewAvailableVehicles(parameters);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
