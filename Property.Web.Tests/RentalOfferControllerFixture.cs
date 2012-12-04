using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Property.DomainContracts.Dtos;
using Property.Web.Controllers;
using Property.Web.Services;

namespace Property.Web.Tests
{
    [TestFixture]
    public class RentalOfferControllerFixture
    {
        private Mock<IAudit> _auditMock;
        private Mock<IQueueWriter> _queueWriter;
        private RentalOfferController _sut;
        private TenantRentalOffer _post;
        private ActionResult _result;

        [SetUp]
        public void SetUp()
        {
            _auditMock = new Mock<IAudit>();
            _queueWriter = new Mock<IQueueWriter>();
            _sut = new RentalOfferController(_auditMock.Object, _queueWriter.Object);
            _post = CreateRentalOfferPost();
            _result = _sut.Create(_post);
        }

        [Test]
        public void SubmittingRentalOffer_AuditsUserRequest()
        {
            _auditMock.Verify(a => a.Audit(_post));
        }
        [Test]
        public void SubmittingRentalOffer_PutRequestOnTenantRentalOfferQueue()
        {
            _queueWriter.Verify(q => q.Enqueue(_post));
        }
        [Test]
        public void SubmittingRentalOffer_RedirectsToPropertyFavourites()
        {
            var result = _result as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Favourites", result.RouteValues["controller"]);
        }

        [Test]
        public void SubmittingRentalOffer_FlashesOfferIsSubmitted()
        {
            //http://stackoverflow.com/questions/5581214/flash-equivalent-in-asp-net-mvc-3 for refactoring
            Assert.AreEqual("You offer has been submitted", _sut.TempData["info"]);
        }

        [Test]
        public void SubmittingRentalOffer_WhenUserNotLogged_AuthorizationException()
        {
            Assert.Fail("Test pending...");
        }
        [Test]
        public void SubmittingRentalOffer_WithInavlidOffer_ReturnToCreateView()
        {
            Assert.Fail("Test pending...");
        }

        private static TenantRentalOffer CreateRentalOfferPost()
        {
            return new TenantRentalOffer();
        }
    }
}
