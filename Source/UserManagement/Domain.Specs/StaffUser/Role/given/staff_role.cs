using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.Role.given
{
    public class staff_role
    {
        public static T build_valid_instance<T>() where T : Domain.StaffUser.StaffRole, new()
        {
            return new T
            {
                YearOfBirth = null,
                Sex = null,
                NationalSociety = Guid.NewGuid(),
                PreferredLanguage = Language.English,
                PhoneNumbers = new string[]{ "999999", "8888888" }
            };
        }

        public static T build_instance_with<T>(IEnumerable<Action< Domain.StaffUser.StaffRole>> invalidations)
            where T : Domain.StaffUser.StaffRole, new()
        {
            var role = build_valid_instance<T>();
            foreach(var invalidate in invalidations)
            {
                invalidate(role);
            }
            return role;
        }


        public static T build_instance_with<T>(Action< Domain.StaffUser.StaffRole> invalidate)
            where T : Domain.StaffUser.StaffRole, new()
        {
            return build_instance_with<T>(new Action< Domain.StaffUser.StaffRole>[]{ invalidate });
        }
    }
}

