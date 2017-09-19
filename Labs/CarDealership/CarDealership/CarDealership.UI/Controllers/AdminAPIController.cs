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
    [Authorize(Roles = "admin")]
    public class AdminAPIController : ApiController
    {
        [Route("api/admin/search")]
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

        [Route("api/admin/searchMakes/{id}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage ModelsSearch(int id)
        {
            var repo = ModelsRepositoryFactory.GetModelsRepository();

            var data = repo.GetModelByMakeId(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
