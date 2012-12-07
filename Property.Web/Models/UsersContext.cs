using System.Data.Entity;

namespace Property.Web.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<PersonalDetails> PersonalDetails { get; set; }
    }
}