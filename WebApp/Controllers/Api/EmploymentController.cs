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
    public class EmploymentController : ApiController
    {
        private ITestRepository repository;

        public EmploymentController(ITestRepository repository)
        {
            this.repository = repository;
        }

        public List<EmployeeModel> GetAllEmployees(string companyName)
        {
            var company = this.repository.FindCompanyByName(companyName);
            if (company == null || company.Employments == null)
            {
                return new List<EmployeeModel>();
            }
            return (from e in company.Employments
                    select new EmployeeModel
                    {
                        Name = e.Employee.Name,
                        CompanyName = companyName,
                        Address = new AddressModel
                        {
                            AddressLine1 = e.Employee.Address?.AddressLine1,
                            AddressLine2 = e.Employee.Address?.AddressLine2,
                            AddressLine3 = e.Employee.Address?.AddressLine3,
                            AddressLine4 = e.Employee.Address?.AddressLine4,
                            FullAddress = string.Format("{0} {1} {2} {3}", e.Employee.Address?.AddressLine1,
                                             e.Employee.Address?.AddressLine2,e.Employee.Address?.AddressLine3,e.Employee.Address?.AddressLine4)
                        },
                        EmploymentStartDate = e.EmploymentStartDate,
                        EmploymentEndDate = e.EmploymentEndDate,
                        NumberOfYearsEmployed = e.NumberOfYearsEmployed
                    }).ToList();
        }

        public void Post([FromBody]EmployeeModel model)
        {
            var company = repository.FindCompanyByName(model.CompanyName);
            if (company != null)
            {
                var employment = new Employment
                {
                    Employee = new Person
                    {
                        Name = model.Name,
                        Address = new Address
                        {
                            AddressLine1 = model.Address?.AddressLine1,
                            AddressLine2 = model.Address?.AddressLine2,
                            AddressLine3 = model.Address?.AddressLine3,
                            AddressLine4 = model.Address?.AddressLine4
                        }
                    },
                    EmploymentStartDate = model.EmploymentStartDate,
                    EmploymentEndDate = model.EmploymentEndDate
                };

                company.Employments.Add(employment);
            }
        }
    }
}
