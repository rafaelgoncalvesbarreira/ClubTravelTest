using System;

namespace Entities
{
    public class Employment
    {
        public Person Employee { get; set; }

        public DateTime EmploymentStartDate { get; set; }

        public DateTime? EmploymentEndDate { get; set; }

        /// <summary>
        ///     Return the number of Years that a employee has been Employed
        /// </summary>
        /// <returns></returns>
        public double NumberOfYearsEmployed
        {
            get {
                var endDate = EmploymentEndDate ?? DateTime.Today;
             
                var differenceYear = endDate.Year - EmploymentStartDate.Year;
                var completeYear = endDate;
                if (endDate.Month < EmploymentStartDate.Month || (endDate.Month==EmploymentStartDate.Month && endDate.Day<EmploymentStartDate.Day))
                {
                    differenceYear--;
                    completeYear.AddYears(-1);
                }
                var daysOfYear = (endDate - completeYear).Days;
                var differenceDays = (endDate.AddYears(differenceYear) - EmploymentStartDate).Days;
                var years = (double)differenceYear + (differenceDays / daysOfYear);
                return years;
            }
        }
    }
}
