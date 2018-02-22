using System;
using System.Collections.Generic;
using System.Text;
using Concepts;

namespace Read.StaffUsers.SystemCoordinator
{
    class SystemCoordinator
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public SystemException Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        //public String GeoLocation { get; set; } //TODO: ??
        public List<string> MobilePhoneNumbers { get; set; }
        public bool MobilePhoneNumberConfirmed { get; } = true;
        public List<Guid> AssignedNationalSociety { get; set; }

    }
}
