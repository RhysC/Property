using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Property.Domain.Tests
{
    [TestFixture]
    public class OfferServiceFixture
    {
        public class GivenOfferIsFromUnRegiusteredUser{}
        public class GivenOfferIsFromUserWhoHasNotViewedTheProperrty{}
        public class GivenOfferIsFirstOfferFromUser{}
        public class GivenOfferIsFromUser{}

        [Test]
        public void AssertNUnitWorks()
        {
            Assert.IsFalse(true);
        }
       
    }
}
