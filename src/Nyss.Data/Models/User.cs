using System.Collections.Generic;
using Nyss.Data.Concepts;

namespace Nyss.Data.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        public string IdentityUserId { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string AdditionalPhoneNumber { get; set; }

        public string Organization  { get; set; }

        public bool IsFirstLogin { get; set; } = true;
        
        public virtual ApplicationLanguage ApplicationLanguage { get; set; }

        public virtual ICollection<UserNationalSociety> UserNationalSocieties { get; set; }
    }
}
