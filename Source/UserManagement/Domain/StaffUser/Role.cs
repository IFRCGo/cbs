using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public interface IRole
    {
        RoleType Type { get; }
    }

    public abstract class Role : IRole
    {
        protected Role(RoleType type)
        {
            Type = type;
            PreferredLanguage = Language.English;
            PhoneNumbers = new string[0];
        }
        //public Location Location { get; set; }
        public int? YearOfBirth { get; set; }
        public Sex? Sex { get; set; }
        public Guid? NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }

        public RoleType Type { get; }
    }
}