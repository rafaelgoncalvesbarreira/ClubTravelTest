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

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        public void Post([FromBody]CompanyModel company)
        {
            switch (company.CompanyType)
            {
                case CompanyTypeEnum.Irish:
                    SaveAsIrishCompany(company);
                    break;
                case CompanyTypeEnum.Foreign:
                    SaveAsForeignCompany(company);
                    break;
                case CompanyTypeEnum.SoleTrader:
                    SaveAsSoleTrader(company);
                    break;
                default:
                    break;
            }
        }

        private void SaveAsIrishCompany(CompanyModel company)
        {
            var irishCompany = new IrishCompany
            {
                Name = company.Name,
                EmployerRegisteredNumber = company.EmployerRegisteredNumber
            };

            this.repository.InsertIrishCompany(irishCompany);
        }

        private void SaveAsForeignCompany(CompanyModel company)
        {
            var foreignCompany = new ForeignCompany
            {
                Name = company.Name,
                InternationBusinessNumber = company.InternationBusinessNumber
            };

            this.repository.InsertForeignCompany(foreignCompany);
        }

        private void SaveAsSoleTrader(CompanyModel company)
        {
            var solerTrader = new SoleTrader
            {
                Name = company.Name,
                Ppsn = company.Ppsn
            };

            this.repository.InsertSoleTraderCompany(solerTrader);
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
