using MyFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyFirstApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdsController : ApiController
    {
        IDvdRepository _repo;
        public DvdsController(IDvdRepository repo)
        {
            _repo = repo;
        }
        public DvdsController(): this(new DvdRepository())
        {

        }
        // GET: api/Dvds
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAll());
        }

        // GET: api/Dvds/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetById(id));
        }

        // POST: api/Dvds
        public HttpResponseMessage Post([FromBody]Dvd value)
        {
            _repo.Create(value);
            return Request.CreateResponse(HttpStatusCode.Created, value);
        }

        // PUT: api/Dvds/5
        public HttpResponseMessage Put(int id, [FromBody]Dvd value)
        {
            _repo.Update(value);
            return Request.CreateResponse(HttpStatusCode.NoContent, value);
        }

        // DELETE: api/Dvds/5
        public HttpResponseMessage Delete(int id)
        {
            _repo.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);

        }
    }
}
