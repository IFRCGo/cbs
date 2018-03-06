using System;

namespace Read.StaffUsers
{
    /// <summary>
    /// The idea is that this class can contain all the different kinds of StaffUsers.
    /// We used this idea in VolunteerReporting to supply the view with a single class that can contain the diferent 
    /// read models that are derived from the same read model type.
    /// 
    /// We probaably don't need all of these fields, we just need the fields specific for the view. Fields can be removed
    /// here as we see fit.
    /// </summary>
    public class StaffUser
    {
        public Guid StaffUserId { get; set; }
        
        //public _Role Role { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public StaffUser(Guid staffUserId,/* _Role role,*/ string fullName, string displayName, 
            string email, DateTimeOffset registrationDate)
        {
            StaffUserId = staffUserId;
            //Role = role;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegistrationDate = registrationDate;
        }

    }

}
