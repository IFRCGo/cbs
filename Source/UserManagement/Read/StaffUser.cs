using System;
using Concepts;
using Events;

namespace Read
{
    public class StaffUser
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; } //TODO: fix when location strucutre is known
        public string GeoLocation { get; set; } //TODO: use GeoCoordinate
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }

        public StaffUser()
        {
        }

        public StaffUser(StaffUserAdded @event)
        {
            Id = @event.Id;
            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Age = @event.Age;
            Sex = @event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = @event.PreferredLanguage;
            Location = @event.Location;
            GeoLocation = @event.GeoLocation;
            MobilePhoneNumber = @event.MobilePhoneNumber;
            Email = @event.Email;
        }
    }
}