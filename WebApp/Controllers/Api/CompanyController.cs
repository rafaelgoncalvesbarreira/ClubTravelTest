using Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers.Api
{
    public class CompanyController : ApiController
    {
        private ITestRepository repository;

        public CompanyController(ITestRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Company
        public IEnumerable<CompanyModel> Get()
        {
            return (from company in repository.FindAllCompanies()
                    select new CompanyModel
                    {
                        Name = company.Name
                    });
        }
    }
}
