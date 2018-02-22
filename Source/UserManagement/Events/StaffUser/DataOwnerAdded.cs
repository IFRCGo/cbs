using System;
using System.Collections.Generic;
using System.Text;

namespace Events.StaffUser
{
    class DataOwnerAdded
    {
        /*
         * public Guid Id;
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public SystemException Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public String GeoLocation { get; set; } //TODO: ??
        public List<string> MobilePhoneNumbers { get; set; }
        public bool MobilePhoneNumberConfirmed { get; } = true;
        public List<Guid> AssignedNationalSociety { get; set; }
        public string Position { get; set; } //TODO: (free text, position within the NS) ?
        public String DutyStation { get; set; }
         */
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public int Sex { get; private set; }
        public Guid NationalSociety { get; private set; }
        public int PreferredLanguage { get; private set; }
        public double LocationLongitude { get; private set; }
        public double LocationLatitude { get; private set; }
        public string GeoLocation { get; private set; }
        public string MobilePhoneNumber { get; private set; }
        public bool MobilePhoneNumberConfirmed { get; private set; } = true;
        public Guid AssignedNationalSociety { get; private set; }
        public string Position { get; private set; }
        public string DutyStation { get; private set; }

        public DataOwnerAdded(Guid id, string fullName, string displayName, string email, int age, 
            int sex, Guid nationalSociety, int preferredLanguage, double locationLongitude, double locationLatitude, 
            string geoLocation, string mobilePhoneNumber, Guid assignedNationalSociety, 
            string position, string dutyStation)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            Age = age;
            Sex = sex;
            NationalSociety = nationalSociety;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
            GeoLocation = geoLocation;
            MobilePhoneNumber = mobilePhoneNumber;
            AssignedNationalSociety = assignedNationalSociety;
            Position = position;
            DutyStation = dutyStation;
        }
    }
}
