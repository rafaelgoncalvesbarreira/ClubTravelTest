using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{

    public class EmployeeModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public AddressModel Address { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public double NumberOfYearsEmployed { get; set; }
    }

    public class AddressModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string FullAddress { get; set; }
    }
}