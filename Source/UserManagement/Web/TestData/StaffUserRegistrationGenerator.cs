using System;
using Concepts;
using Domain.StaffUser;
using Domain.StaffUser.Registering;

namespace Web.TestData
{
    /// <summary>
    /// Basicly just a copy of Domain.Specs/StaffUser/Registering/given/commands.cs
    /// 
    /// Perhaps replace this with something more robust and flexible in the future
    /// </summary>
    public class StaffUserRegistrationGenerator
    {
        
        public static T GenerateDefaultNewStaffRegistration<T>() where T : INewStaffRegistration, new()
        {
            var cmd = new T();
            PopulateStaffDetails(cmd);
            PopulateSex(cmd);
            PopulatePreferredLanguage(cmd);
            PopulateNationalSociety(cmd);
            PopulateBirthYear(cmd);
            PopulatePhoneNumbers(cmd);
            PopulateAssignedNationalSocieties(cmd);
            PopulatePosition(cmd);
            PopulateDutyStation(cmd);
            PopulateLocation(cmd);

            return cmd;
        }

        private static void PopulateStaffDetails<T>(T instance) where T : INewStaffRegistration, new()
        {
            var inst = (instance as dynamic).Role;

            inst.StaffUserId = Guid.NewGuid();
            inst.Email = "user@redcross.no";
            inst.FullName = "Our New User";
            inst.DisplayName = "Joe";
        }

        private static void PopulatePreferredLanguage<T>(T instance) where T : INewStaffRegistration, new()
        {
            var prefLang = (instance as dynamic).Role as IRequirePreferredLanguage;

            if (prefLang == null)
                return;

            (prefLang as dynamic).PreferredLanguage = Language.English;
        }

        private static void PopulateSex<T>(T instance) where T : INewStaffRegistration, new()
        {
            var sex = (instance as dynamic).Role as IRequireSex;

            if (sex == null)
                return;

            (sex as dynamic).Sex = Sex.Female;
        }

        private static void PopulateNationalSociety<T>(T instance) where T : INewStaffRegistration, new()
        {
            var natSec = (instance as dynamic).Role as IRequireNationalSociety;

            if (natSec == null)
                return;

            (natSec as dynamic).NationalSociety = Guid.NewGuid();
        }

        private static void PopulateDutyStation<T>(T instance) where T : INewStaffRegistration, new()
        {
            var dutyStation = (instance as dynamic).Role as IRequireDutyStation;

            if (dutyStation == null)
                return;

            (dutyStation as dynamic).DutyStation = "duty station";
        }

        private static void PopulatePosition<T>(T instance) where T : INewStaffRegistration, new()
        {
            var pos = (instance as dynamic).Role as IRequirePosition;

            if (pos == null)
                return;

            (pos as dynamic).Position = "position";
        }

        private static void PopulateBirthYear<T>(T instance) where T : INewStaffRegistration, new()
        {
            var year = (instance as dynamic).Role as IRequireBirthYear;

            if (year == null)
                return;

            (year as dynamic).BirthYear = 1980;
        }

        private static void PopulatePhoneNumbers<T>(T instance) where T : INewStaffRegistration, new()
        {
            var numbers = (instance as dynamic).Role as IRequirePhoneNumbers;

            if (numbers == null)
                return;

            (numbers as dynamic).PhoneNumbers = new [] { "1234567", "2345678" };
        }

        private static void PopulateAssignedNationalSocieties<T>(T instance) where T : INewStaffRegistration, new()
        {
            var numbers = (instance as dynamic).Role as IRequireAssignedNationalSocieties;

            if (numbers == null)
                return;

            (numbers as dynamic).AssignedNationalSocieties = new [] { Guid.NewGuid(), Guid.NewGuid() };
        }

        private static void PopulateLocation<T>(T instance) where T : INewStaffRegistration, new()
        {
            var loc = (instance as dynamic).Role as IRequireLocation;

            if (loc == null)
                return;

            (loc as dynamic).Location = new Location(45, 45);
        }
    }
}