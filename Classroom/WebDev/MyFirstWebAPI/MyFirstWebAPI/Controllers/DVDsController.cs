using MyFirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyFirstWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDsController : ApiController
    {
        IDVDRepository _repo;
        public DVDsController(IDVDRepository repo)
        {
            _repo = repo;
        }
        public DVDsController(): this(new DVDRepository())
        {

        }

        // GET: api/DVDs
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAll());
        }

        // GET: api/DVDs/5
        [Route("api/DVD/{id}")] //casing of id in {} must match casing of parameter going into get
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.Get(id));
        }

        // POST: api/DVDs
        public HttpResponseMessage Post([FromBody]DVD value)
        {
            _repo.Create(value);
            return Request.CreateResponse(HttpStatusCode.Created, value);
        }

        // PUT: api/DVDs/5
        [Route("api/DVD/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]DVD value)
        {
            value.Id = id;
            _repo.Edit(value);
            return Request.CreateResponse(HttpStatusCode.NoContent, value);
        }

        // DELETE: api/DVDs/5
        [Route("api/DVD/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _repo.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
