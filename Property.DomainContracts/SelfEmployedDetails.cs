using System;

public class SelfEmployedDetails
{
    public Money Previous12MonthsRevenue { get; set; }
    public Money Previous12MonthsSalaryAndDiviendPaidToSelf { get; set; }
    public string CompanyName { get; set; }
    public TimeSpan TimeHaveBeenSelfEmployed { get; set; }
    public RefereeDetails RefereeDetails { get; set; }
        
}