using System;

namespace Property.DomainContracts
{
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
}