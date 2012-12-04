using Property.DomainContracts.Dtos;

namespace Property.DomainContracts.Services
{
    public interface IRentalOfferService
    {
        void SubmitRentalOffer(TenantRentalOffer rentalOffer);
    }
}
