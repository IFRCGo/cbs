using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public class ExtendedInfo
    {
        public ExtendedInfo()
        {
            PreferredLanguage = Language.English;
            PhoneNumbers = new string[0];
        }
        //public Location Location { get; set; }
        public int? YearOfBirth { get; set; }
        public Sex? Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}