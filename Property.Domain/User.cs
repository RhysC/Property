using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain
{
    public interface IUser
    {
        bool CanMakeOffer();
    }
    public class User : IUser
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly Dictionary<string, string> _contacts = new Dictionary<string, string>();
        private readonly string[] _contactTypesRequiredForOffer = new string[] { ContactType.MobilePhone };

        public User(int loginId, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("firstName");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("lastName");
            _firstName = firstName;
            _lastName = lastName;
        }

        public bool CanMakeOffer()
        {
            return _contacts.Any(kvp => _contactTypesRequiredForOffer.Contains(kvp.Key));
        }

        public void AddContact(string contactType, string details)
        {
            _contacts.Add(contactType, details);
        }
    }
}
