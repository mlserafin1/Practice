using DVDLibrary.BLL;
using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        DvdManager manager = DvdRepoFactory.Create();

        // GET: api/Dvd
        [Route("Dvds")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.GetAll());
        }

        // GET: api/Dvd/5
        [Route("Dvd/{id}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.GetById(id));
        }

        // POST: api/Dvd
        [Route("Dvd")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage Post([FromBody]Dvd dvd)
        {
            manager.Create(dvd);
            dvd.Id = dvd.Id;
            return Request.CreateResponse(HttpStatusCode.Created, dvd);
        }

        // PUT: api/Dvd/5
        [Route("Dvd/{id}")]
        [AcceptVerbs("PUT")]
        public HttpResponseMessage Put(int id, [FromBody]Dvd dvd)
        {
            dvd.Id = id;
            manager.Update(dvd);
            return Request.CreateResponse(HttpStatusCode.NoContent, dvd);
        }

        // DELETE: api/Dvd/5
        [Route("Dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public HttpResponseMessage Delete(int id)
        {
            manager.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [Route("Dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetTitle(string title)
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.SearchForTitle(title));
        }

        [Route("Dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetYear(string releaseYear)
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.SearchForYear(releaseYear));
        }

        [Route("Dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetDirector(string directorName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.SearchForDirector(directorName));
        }

        [Route("Dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetRating(string rating)
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.SearchForRating(rating));
        }
    }
}
