using System;

namespace Property.Domain
{
    /*
     * i dont think this is a domain object and it has been moved to DTOs - pending delete, post commit
     */

    public class TenantRentalOffer
    {
        public Term Term { get; set; }
        public DateTime BreakDate { get; set; }
        public DateTime ProposedStartDate { get; set; }
        public int NumberofTenants { get; set; }
        //public TenacyType TenacyType { get; set; }
        public Money ProposedRent { get; set; }
        public TimeSpan ProposedFrequency { get; set; }
        public PaymentDetails AdditionalPaymentDetails { get; set; }//Proposed payment details - I can select if I will pay monthly in advance, quarterly in advance, 6 months in advance
        public Money Deposit { get; set; }
        public string AdditonalRequirements { get; set; }
        public TenantDetail[] TenantDetails { get; set; }

        //public User SubmittedBy{ get; set; }
    }

    public class TenantDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string PlaceOfBirth { get; set; } //Is this an address?
        public AddressDetails[] PreviousAddressDetails { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasPets { get; set; }
        public bool HasBeenEvictedFromAPreviousProperty { get; set; }
        public bool HasCriminalConvictions { get; set; }
        public bool RequiresHousingSupportToPayRent { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public EmploymentDetails[] EmploymentDetails { get; set; }
        public Guarantor Guarantor { get; set; }
        public SelfEmployedDetails SelfEmployedDetails { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public RetireeDetails RetireeDetails { get; set; }
        public string AdditionalDetails { get; set; }
        public RefereeDetails CharacterRefereeDetails { get; set; }
    }

    public class RetireeDetails
    {
        public Money AnnualPensionIncome { get; set; }
    }


    public class StudentDetails
    {
        public string AttendedTertiaryInstition { get; set; }
        public string CourseName { get; set; }
        public string IntendedMeansOfPayment { get; set; }//If a student I need to enter how I will pay the rent - savings, family, spouse
        public Guarantor Guarantor { get; set; }

    }

    public class SelfEmployedDetails
    {
        public Money Previous12MonthsRevenue { get; set; }
        public Money Previous12MonthsSalaryAndDiviendPaidToSelf { get; set; }
        public string CompanyName { get; set; }
        public TimeSpan TimeHaveBeenSelfEmployed { get; set; }
        public RefereeDetails RefereeDetails { get; set; }
        
    }

    public class RefereeDetails
    {
        public string RefereeName { get; set; }
        public string RefereeContactDetails { get; set; }
        public string NameOfEmployer { get; set; }
        public string Relationship { get; set; }
    }

    public class Guarantor
    {
        public string Name { get; set; }
        public EmploymentDetails[] EmploymentDetails { get; set; }
        public ContactDetails ContactDetails { get; set; }

    }

    public class ContactDetails 
    {
        public ContactType Type { get; set; }
        public string Details { get; set; }
    }

    public class EmploymentDetails
    {
        public Money GrossAnnualIncome { get; set; }
        public string NameOfEmployer { get; set; }
        public string Position { get; set; }
        public TimeSpan TimeWithCurrentEmployer { get; set; }//perhaps a form and to date?
    }

    public enum EmploymentStatus
    {
        Employed,
        SelfEmployed,
        Student,
        Retired,
        Other
    }

    public enum MaritalStatus
    {
        Single,
        Defacto,
        Married
    }

    public class AddressDetails
    {
        public Address Address { get; set; }
        public TimeSpan CurrentAddress { get; set; }//perhaps a form and to date?
        public LivingArrangement LivingArrangementAtAddress { get; set; }
    }

    public enum LivingArrangement
    {
        Renting,
        Owner,
        LivingWithRelatives
    }

    public class Address
    {
    }

    public class PaymentDetails
    {
    }

    public class Term
    {
    }

    public class Money
    {
    }
}
