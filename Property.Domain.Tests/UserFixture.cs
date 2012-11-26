using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Property.Domain;

namespace Property.Domain.Tests
{
    [TestFixture]
    public class UserFixture
    {
        [Test]
        public void CannotCreateUserWithNullFirstName()
        {
            Assert.Throws<ArgumentException>(()=> new User(1, null, "campbell"));
        }
        [Test]
        public void CannotCreateUserWithEmptyFirstName()
        {
            Assert.Throws<ArgumentException>(() => new User(1, "   ", "campbell"));
        }
        [Test]
        public void CannotCreateUserWithNullLastName()
        {
            Assert.Throws<ArgumentException>(() => new User(1, "rhys", null));
        }
        [Test]
        public void CannotCreateUserWithEmptyLastName()
        {
            Assert.Throws<ArgumentException>(() => new User(1, "rhys","   "));
        }
        [Test]
        public void UserWithNoPhoneNumberCannotMakeAnOffer()
        {
            var user = new User(1, "rhys", "campbell");
            Assert.False(user.CanMakeOffer());
        }

        [Test]
        public void UserWithNameAndPhoneNumberCanMakeAnOffer()
        {
            var user = new User(1, "rhys", "campbell");
            user.AddContact(ContactType.MobilePhone, "0404 305458");
            Assert.True(user.CanMakeOffer());
        }
    }
}
