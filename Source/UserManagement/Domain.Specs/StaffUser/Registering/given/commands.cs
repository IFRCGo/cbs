using Domain.StaffUser;
using Domain.StaffUser.Registering;
using System.Collections.Generic;
using System;
using Concepts;

namespace Domain.Specs.StaffUser.Registering.given
{
    public class commands
    {
        public static T build_valid_instance<T>() where T : NewStaffRegistration, new()
        {
            var cmd = new T();
            PopulateStaffDetails(cmd);
            PopulateSex(cmd);
            PopulatePreferredLanguage(cmd);
            PopulateNationalSociety(cmd);
            PopulateBirthYear(cmd);
            PopulatePhoneNumbers(cmd);
            return cmd;
        }

        static void PopulateStaffDetails<T>(T instance) where T : NewStaffRegistration, new()
        {
            instance.StaffUserId = Guid.NewGuid();
            instance.Email = "user@redcross.no";
            instance.FullName = "Our New User";
            instance.DisplayName = "Joe";
        }

        static void PopulatePreferredLanguage<T>(T instance) where T : NewStaffRegistration, new() 
        {
            var prefLang = instance as IRequirePreferredLanguage;

            if(prefLang == null)
                return;

            (prefLang as dynamic).PreferredLanguage = Language.English;
        }

        static void PopulateSex<T>(T instance) where T : NewStaffRegistration, new() 
        {
            var sex = instance as IRequireSex;

            if(sex == null)
                return;

            (sex as dynamic).Sex = Sex.Female;
        }

        static void PopulateNationalSociety<T>(T instance) where T : NewStaffRegistration, new() 
        {
            var natSec = instance as IRequireNationalSociety;

            if(natSec == null)
                return;

            (natSec as dynamic).NationalSociety = Guid.NewGuid();
        }

        static void PopulateBirthYear<T>(T instance) where T : NewStaffRegistration, new() 
        {
            var year = instance as IRequireBirthYear;

            if(year == null)
                return;

            (year as dynamic).BirthYear = 1980;
        }

        static void PopulatePhoneNumbers<T>(T instance) where T : NewStaffRegistration, new() 
        {
            var numbers = instance as IRequirePhoneNumbers;

            if(numbers == null)
                return;

            (numbers as dynamic).PhoneNumbers = new string[]{ "1234567", "2345678"};
        }
    }
}