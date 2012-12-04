using System;
using TechTalk.SpecFlow;

namespace Property.Domain.Specs
{
    [Binding]
    public class RentalOffersFromInvalidUsersSteps
    {
        User _user;
        Guid _propertyId = Guid.NewGuid();
        

        [When]
        public void When_I_make_an_offer()
        {
            var offer = ObjectMother.NewRentalOffer().Create();
            rentalOfferService.PlaceOffer(_user, _propertyId, offer);
        }
    }
    public class ObjectMother
    {
        public static UserFactory NewUser()
        {
            return new UserFactory();
        }
        public static RentalOfferFactory NewRentalOffer()
        {
            return new RentalOfferFactory();
        }
    }
    public class RentalOfferFactory
    {
        public Offer Create() { return new Offer(); }
    }
    public class UserFactory
    {
        private Func<string> _createPhone = () => "0404 1234 5678";
        public UserFactory WithNoContactDetails()
        {
            this._createPhone = () => "";
            return this;
        }

        public User Create()
        {
            return new User { Phone = _createPhone() };
        }
    }
    public class User
    {
        public string Phone { get; set; }
    }
    public class Offer
    {

    }

}
