using ContactListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactListAPI.Controllers
{
    
    public class ContactsController : ApiController
    {
        IContactRepository _repo;
        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }
        public ContactsController(): this(new ContactRepository())
        {

        }

        // GET: api/Contacts
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAll());
        }

        // GET: api/Contacts/5
        [Route("api/Contact/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _repo.GetById(id));
        }

        // POST: api/Contacts
        public HttpResponseMessage Post([FromBody]Contact value)
        {
            _repo.Create(value);
            return Request.CreateResponse(HttpStatusCode.Created, value);
        }

        // PUT: api/Contacts/5
        [Route("api/Contact/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Contact value)
        {
            value.Id = id;
            _repo.Update(value);
            return Request.CreateResponse(HttpStatusCode.NoContent, value);
        }

        // DELETE: api/Contacts/5
        [Route("api/Contact/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _repo.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
