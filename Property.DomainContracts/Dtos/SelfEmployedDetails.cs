using System;

namespace Property.DomainContracts.Dtos
{
    public class SelfEmployedDetails
    {
        public decimal PreviousYearsRevenue { get; set; }
        public decimal PreviousYearsSalaryAndDiviendPaidToSelf { get; set; }
        public string CompanyName { get; set; }
        public TimeSpan TimeHaveBeenSelfEmployed { get; set; }
        public RefereeDetails RefereeDetails { get; set; }
        
    }
}