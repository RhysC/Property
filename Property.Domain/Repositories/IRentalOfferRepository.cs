namespace Property.Domain.Repositories
{
    public interface IRentalOfferRepository
    {
        TenantRentalOffer GetNextPendingOffer();
    }
}
