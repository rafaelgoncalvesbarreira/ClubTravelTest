using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CountAllCompanies();
            app.AllEmployeesInIreland();
            app.AllEmployeesYearsWorked();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }

        public void CountAllCompanies()
        {
            var repository = new TestRepository();
            var count = repository.FindAllCompanies().Count;
            Console.WriteLine(string.Format("{0} companies found!", count));
        }

        public void AllEmployeesInIreland()
        {
            var repository = new TestRepository();
            var irishCompany = repository.FindAllCompanies().FirstOrDefault(c => c.Name == "Irish1");
            if (irishCompany != null)
            {
                foreach (var employee in irishCompany.Employments)
                {
                    Console.WriteLine(employee.Employee.Name);
                }
            }
        }

        public void AllEmployeesYearsWorked()
        {
            var repository = new TestRepository();
            foreach (var company in repository.FindAllCompanies())
            {
                double allYearsWorked = 0;
                if (company.Employments != null)
                {
                    allYearsWorked = company.Employments.Select(e => e.NumberOfYearsEmployed).Sum();
                }
                Console.WriteLine(string.Format("Company \"{0}\" has a total of {1:0.00} years of employments worked",
                    company.Name,
                    allYearsWorked)
                );
            }
        }
    }
}
