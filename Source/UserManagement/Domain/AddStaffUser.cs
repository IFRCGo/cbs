using System;
using Concepts.enums;

namespace Domain
{
    public class AddStaffUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PrefferedLanguage { get; set; }
        //public string Location { get; set; } //TODO: fix when location strucutre is known
        //public GeoCoordinate GeoLocation { get; set; } //TODO: use GeoCoordinate
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
