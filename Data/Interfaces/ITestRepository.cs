using System.Collections.Generic;
using Entities;

namespace Data.Interfaces
{
    public interface ITestRepository
    {
        List<Company> FindAllCompanies();
        Company FindCompanyByName(string companyName);
    }
}
