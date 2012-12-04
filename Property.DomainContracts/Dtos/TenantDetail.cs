using System;

namespace Property.DomainContracts.Dtos
{
    public class TenantDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string PlaceOfBirth { get; set; } //Is this an address?
        public AddressDetails[] PreviousAddressDetails { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public bool? IsSmoker { get; set; }
        public bool? HasPets { get; set; }
        public bool? HasBeenEvictedFromAPreviousProperty { get; set; }
        public bool? HasCriminalConvictions { get; set; }
        public bool? RequiresHousingSupportToPayRent { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public EmploymentDetails[] EmploymentDetails { get; set; }
        public Guarantor Guarantor { get; set; }
        public SelfEmployedDetails SelfEmployedDetails { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public RetireeDetails RetireeDetails { get; set; }
        public string AdditionalDetails { get; set; }
        public RefereeDetails CharacterRefereeDetails { get; set; }

        public static TenantDetail CreateDefault()
        {
            return new TenantDetail();
        }
    }
}