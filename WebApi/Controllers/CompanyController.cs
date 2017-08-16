using Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private ITestRepository repository;

        public CompanyController(ITestRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            return repository.FindAllCompanies();
        }

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
