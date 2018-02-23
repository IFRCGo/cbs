using System;
using System.Collections.Generic;
using System.Text;
using doLittle.Events;

namespace Events.StaffUser
{
    public class DataCoordinatorAdded : IEvent
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
        public Location GeoLocation { get; set; } //TODO: ??
        public List<string> MobilePhoneNumbers { get; set; }
        public bool MobilePhoneNumberConfirmed { get; } = true;
        public List<Guid> AssignedNationalSociety { get; set; }
         */

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public int Sex { get; private set; } // 0 is male 1 is female
        public Guid NationalSociety { get; private set; }
        public int PreferredLanguage { get; private set; } // 0 is english 1 is french TODO Must be another way to do this.
        public double LocationLongitude { get; private set; }
        public double LocationLatitude { get; private set; }
        public string GeoLocation { get; private set; }
        //TODO: Do we event want to have mobile number in event?
        public string MobilePhoneNumber { get; private set; } // TODO: A DataCoordinator can have multiple phonenumbers, 
        // though I guess we cannot have List objects in events??
        public bool MobilePhoneNumberConfirmed { get; private set; } = true;
        public Guid AssignedNationalSociety { get; private set; }// TODO: A DataCoordinator can have multiple Assigned national societies,
        // though I guess we cannot have List objects in events??

        public DataCoordinatorAdded(Guid id, string fullName, string displayName, string email, int age, 
            int sex, Guid nationalSociety, int preferredLanguage, double locationLongitude, double locationLatitude, 
            string geoLocation, string mobilePhoneNumber, Guid assignedNationalSociety)
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
        }



    }
}
