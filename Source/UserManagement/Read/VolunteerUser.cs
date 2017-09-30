using System;
using Concepts.enums;
using Events;

namespace Read
{
    public class VolunteerUser{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string GpsLocation { get; set; }
        public string MobilePhoneNumber{ get; set; }
        public string Email { get; set; }

        public VolunteerUser() { }

        public VolunteerUser(VolunteerUserAdded @event)
        {
            Id = @event.Id;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Age = @event.Age;
            Sex = @event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = @event.PreferredLanguage;
            GpsLocation = @event.GpsLocation;
            MobilePhoneNumber = @event.MobilePhoneNumber;
            Email = @event.Email;
        }
    }
}
