using System;

namespace Property.DomainContracts.Dtos
{
    public class EmploymentDetails
    {
        public decimal GrossAnnualIncome { get; set; }
        public string NameOfEmployer { get; set; }
        public string Position { get; set; }
        public TimeSpan TimeWithCurrentEmployer { get; set; }//perhaps a form and to date?
    }
}