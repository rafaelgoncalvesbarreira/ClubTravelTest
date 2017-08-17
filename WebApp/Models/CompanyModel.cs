using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CompanyModel
    {
        public string Name { get; set; }
        public string EmployerRegisteredNumber { get; set; }
        public string InternationBusinessNumber { get; set; }
        public string Ppsn { get; set; }
        public CompanyTypeEnum CompanyType { get; set; }
    }

    public enum CompanyTypeEnum
    {
        Irish,
        Foreign,
        SoleTrader
    }
}