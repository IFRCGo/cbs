using System;
using System.Collections.Generic;
using Concepts;

namespace Domain
{
    public class AddStaffUser
    {
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public String Position { get; set; }
        public String DutyStation { get; set; }
        public Language PreferredLanguage { get; set; }
        public string Location { get; set; } //TODO: fix when location strucutre is known
        //public GeoCoordinate GeoLocation { get; set; } //TODO: use GeoCoordinate
        public string MobilePhoneNumber { get; set; }
        public List<Guid> AssignedNationalSociety {get; set; }
    }
}
