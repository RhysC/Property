using System;
using System.ComponentModel.DataAnnotations;
namespace Property.DomainContracts.Dtos
{
    public class TenantRentalOffer
    {
        [Required]
        public DateTime ProposedStartDate { get; set; }
        [Required]
        public DateTime IntendedTermEndDate { get; set; }//can either select a term or enter end date
        
        [Required]
        public DateTime BreakDate { get; set; }
        
        [Required]
        public int NumberOfTenants { get; set; }
        //public TenacyType TenacyType { get; set; }

        [Required]
        public decimal ProposedRent { get; set; }
        [Required]
        public PaymentFrequency ProposedPaymentFrequency { get; set; }
        [Required]
        public decimal Deposit { get; set; }
        //[DataType(DataType.MultilineText)]
        //public PaymentDetails AdditionalPaymentDetails { get; set; }//Proposed payment details - I can select if I will pay monthly in advance, quarterly in advance, 6 months in advance

        [DataType(DataType.MultilineText)]
        public string AdditonalRequirements { get; set; }


        public TenantDetail[] TenantDetails { get; set; }

        //public User SubmittedBy{ get; set; }
        public static TenantRentalOffer CreateDefault()
        {
            var start = DateTime.Now.AddDays(7).Date;
            var end = start.AddYears(2);
            var breakDate = start.AddMonths(6);
            var proposedRent = 500;
            var freq = PaymentFrequency.Weekly;
            var deposit = proposedRent*6;
            return new TenantRentalOffer
                {
                    ProposedStartDate = start,
                    IntendedTermEndDate = end,
                    BreakDate = breakDate,
                    Deposit = deposit,
                    ProposedPaymentFrequency = freq,
                    ProposedRent = proposedRent,
                    NumberOfTenants = 2,
                    TenantDetails = new TenantDetail[]
                        {
                            TenantDetail.CreateDefault(),
                            TenantDetail.CreateDefault()
                        }
                };
        }
    }
}