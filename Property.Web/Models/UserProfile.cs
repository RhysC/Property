using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Web.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual PersonalDetails PersonalDetails { get; set; }
    }

    public class PersonalDetails
    {
        public PersonalDetails()
        {
            ContactDetails = new Collection<ContactInformation>();
        }
        public int Id { get; set; }
        [Required]
        public virtual UserProfile Profile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<ContactInformation> ContactDetails { get; set; }

        public static PersonalDetails Default(string email)
        {
            return new PersonalDetails { Email = email};
        }
    }

    public class ContactInformation
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Details { get; set; }
    }

    public enum ContactType
    {
        Email = 1,
        MobilePhone = 2,
        HomePhone = 3,
        WorkPhone = 4,
        Other = 5
    }
}