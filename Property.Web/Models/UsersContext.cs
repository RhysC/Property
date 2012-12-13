using System.Data.Entity;
using Property.Web.Models.Landlord;

namespace Property.Web.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        //consider these model to implementa an interface eg IHaveUser and then a repository can wrap retival and validate they can actually see that instance

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<PersonalDetails> PersonalDetails { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<PropertyDescription> PropertyDescriptions { get; set; }
    }
}