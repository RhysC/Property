using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Property.DomainContracts.Dtos;

namespace Property.Web.Tests
{
    [TestFixture]
    public class TenantRentalOfferDtoFixture
    {
        [Test]
        public void Can_Serialize_Dto()
        {
            var dto = CreateDto();

            Assert.Fail("Test pending...");
        }

        private static TenantRentalOffer CreateDto()
        {
            return new TenantRentalOffer
                 {
                     ProposedStartDate = DateTime.Now.AddDays(7).Date,
                     IntendedTermEndDate = DateTime.Now.AddDays(7).AddYears(2).Date,
                     BreakDate = DateTime.Now.AddDays(7).AddMonths(6).Date,
                     Deposit = 600,
                     ProposedPaymentFrequency = PaymentFrequency.Weekly,
                     ProposedRent = 100,
                     NumberOfTenants = 2,
                     TenantDetails = new TenantDetail[]
                        {
                            new TenantDetail
                                {
                                    FirstName = "Bob",
                                    LastName = "Bishop",
                                    DateOfBirth = new DateTime(1980,01,1),
                                    HasBeenEvictedFromAPreviousProperty = false,
                                    HasCriminalConvictions = false,
                                    HasPets = true,
                                    IsSmoker = true,
                                    AdditionalDetails = "wants to pay on the 20th of the month",
                                    CharacterRefereeDetails = new RefereeDetails
                                        {
                                            NameOfEmployer = "WorldCorp",
                                            RefereeName = "Mr Big",
                                            Relationship = "Former boss",
                                            RefereeContactDetails = "mrbig@worldcorp.com"
                                        },
                                    EmploymentDetails = new EmploymentDetails[]
                                        {
                                            new EmploymentDetails
                                                {
                                                    NameOfEmployer = "MediumCorp",
                                                    GrossAnnualIncome = 99000.00m,
                                                    Position = "Middle Management",
                                                    TimeWithCurrentEmployer = TimeSpan.FromDays(365/2)
                                                },
                                            new EmploymentDetails
                                                {
                                                    NameOfEmployer = "Old School",
                                                    GrossAnnualIncome = 50000.00m,
                                                    Position = "clerk",
                                                    TimeWithCurrentEmployer = TimeSpan.FromDays(730)
                                                }
                                        }

                                },
                            new TenantDetail
                                {
                                    FirstName = "Jane",
                                    LastName = "Jones",
                                    DateOfBirth = new DateTime(1975,01,1),
                                    HasBeenEvictedFromAPreviousProperty = true,
                                    HasCriminalConvictions = false,
                                    HasPets = false,
                                    IsSmoker = true,
                                    AdditionalDetails = "Can i have a reduced deposit?",
                                    CharacterRefereeDetails = new RefereeDetails
                                        {
                                            NameOfEmployer = "Shell",
                                            RefereeName = "Mr Crab",
                                            Relationship = "Former boss",
                                            RefereeContactDetails = "cabby@shell.com"
                                        },
                                    EmploymentDetails = new EmploymentDetails[]
                                        {
                                            new EmploymentDetails
                                                {
                                                    NameOfEmployer = "BP",
                                                    GrossAnnualIncome = 25000.00m,
                                                    Position = "GAs attendent",
                                                    TimeWithCurrentEmployer = TimeSpan.FromDays(90)
                                                },
                                            new EmploymentDetails
                                                {
                                                    NameOfEmployer = "Gull",
                                                    GrossAnnualIncome = 20000.00m,
                                                    Position = "Assistant",
                                                    TimeWithCurrentEmployer = TimeSpan.FromDays(365)
                                                }
                                        }

                                },
                        }
                 };

        }
    }
}
