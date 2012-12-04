using System;
using Property.Domain.Repositories;
using Property.DomainContracts.Dtos;
using Property.DomainContracts.Services;
using TechTalk.SpecFlow;
using Moq;

namespace Property.Domain.Specs
{
    [Binding]
    public class TenantRentalOfferSubmissionSteps
    {
        private IUser _currentUser;
        private readonly Mock<IRentalOfferRepository> _rentalOfferRepositoryMock;
        private readonly Mock<IUserNotificationRepsoitory> _userNotificationRepsoitoryMock;
        private TenantRentalOffer invalidRentalOffer;
        private UserNotification[] invalidRentalOfferNotification;
        private IRentalOfferService _rentalOfferService;
        private DomainContracts.Dtos.TenantRentalOffer offerSubmissionDto;

        public TenantRentalOfferSubmissionSteps()
        {
            _rentalOfferRepositoryMock = new Mock<IRentalOfferRepository>();
        }

        [Given]
        public void Given_I_have_not_logged_on()
        {
            _currentUser = null;
        }
        
        [Given]
        public void Given_my_user_is_logged_in()
        {
            _currentUser = new Mock<IUser>().Object;
        }
        
        [Given]
        public void Given_an_invalid_offer_has_been_submitted_to_the_RentalOfferPending_queue()
        {
            _rentalOfferRepositoryMock.Setup(r => r.GetNextPendingOffer())
                                      .Returns(invalidRentalOffer);
        }

        [Given]
        public void Given_has_pending_invalid_offer_notifications()
        {
            _userNotificationRepsoitoryMock.Setup(r => r.GetNotificationsFor(_currentUser))
                                           .Returns(invalidRentalOfferNotification);
        }

        //WHEN
        
        [When]
        public void When_I_make_an_offer()
        {
            _rentalOfferService.SubmitRentalOffer(offerSubmissionDto);
        }
        
        [When]
        public void When_the_offer_is_processed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_request_user_notifications()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_open_previous_invalid_offer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_resubmit_the_offer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_remove_the_offer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_an_authorisation_error_will_be_raised()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_the_offer_is_persisted_in_the_RentalOfferPending_queue()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_an_InvalidOfferNotification_is_raised_with_the_offer_and_the_user()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_I_get_an_InvalidOfferNotification()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void Then_the_InvalidOfferNotification_should_be_marked_actioned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
