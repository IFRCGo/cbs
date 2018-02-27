using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain.StaffUser.Update
{
    public class UpdateStaffUser : ICommand
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        // Used for determining what kind of user it is.
        //TODO: QUESTION: Can a user's Role be changed?
        public Role Role { get; set; } 
        public Guid NationalSociety { get; set; }
        public Language PreferedLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public List<string> MobilePhoneNumbersAdded { get; set; }
        public List<string> MobilePhoneNumbersRemoved { get; set; }
        //TODO: QUESTION: Can we both remove and add AssignedNationalServices?
        public List<Guid> AssignedNationalSocieties { get; set; }

        public string Position { get; set; }
        //public string DutyStation {get; set; } seems like this field cannot be edited in DataOwer
    }
}