using System;
using System.Collections.Generic;
using Concepts;
using Events.StaffUser;

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
        public Guid Id { get; set; }
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public List<string> MobilePhoneNumbers { get; set; }
        public bool MobilePhoneNumberConfirmed { get; } = true;
        public List<Guid> AssignedNationalSociety { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string Position { get; set; }
        public string DutyStation { get; set; }

        public StaffUser(AdminAdded @event)
        {
            Role = Role.Admin;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;
        }

        public StaffUser(DataConsumerAdded @event)
        {
            Role = Role.DataConsumer;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;

            Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            
        }
        public StaffUser(DataCoordinatorAdded @event)
        {
            Role = Role.DataCoordinator;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;

            YearOfBirth = @event.YearOfBirth;
            Sex = (Sex) @event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = (Language) @event.PreferredLanguage;
            Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            MobilePhoneNumbers = new List<string>
            {
                @event.MobilePhoneNumber
            };
            AssignedNationalSociety = new List<Guid>
            {
                @event.AssignedNationalSociety
            };
        }

        public StaffUser(DataOwnerAdded @event)
        {
            Role = Role.DataOwner;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;

            YearOfBirth = @event.YearOfBirth; YearOfBirth = @event.YearOfBirth;
            Sex = (Sex)@event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = (Language)@event.PreferredLanguage;
            Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            MobilePhoneNumbers = new List<string>
            {
                @event.MobilePhoneNumber
            };
            AssignedNationalSociety = new List<Guid>
            {
                @event.AssignedNationalSociety
            };
            Position = @event.Position;
            DutyStation = @event.DutyStation;

        }
        public StaffUser(DataVerifierAdded @event)
        {
            Role = Role.DataVerifier;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;

            YearOfBirth = @event.YearOfBirth; YearOfBirth = @event.YearOfBirth;
            Sex = (Sex)@event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = (Language)@event.PreferredLanguage;
            Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            MobilePhoneNumbers = new List<string>
            {
                @event.MobilePhoneNumber
            };
            AssignedNationalSociety = new List<Guid>
            {
                @event.AssignedNationalSociety
            };
            RegistrationDate = @event.RegistrationDate;
        }

        public StaffUser(SystemCoordinatorAdded @event)
        {
            Role = Role.SystemCoordinator;
            Id = @event.Id;

            FullName = @event.FullName;
            DisplayName = @event.DisplayName;
            Email = @event.Email;

            YearOfBirth = @event.YearOfBirth; YearOfBirth = @event.YearOfBirth;
            Sex = (Sex)@event.Sex;
            NationalSociety = @event.NationalSociety;
            PreferredLanguage = (Language)@event.PreferredLanguage;
            Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            MobilePhoneNumbers = new List<string>
            {
                @event.MobilePhoneNumber
            };
            AssignedNationalSociety = new List<Guid>
            {
                @event.AssignedNationalSociety
            };
        }
    }
}
