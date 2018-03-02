using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.Role.given
{
    public class role
    {
        public static Domain.StaffUser.Role build_valid_instance()
        {
            return new BasicRole(Domain.StaffUser.RoleType.Admin)
            {
                //Location = new Location(45,45),
                YearOfBirth = null,
                Sex = null,
                NationalSociety = Guid.NewGuid(),
                PreferredLanguage = Language.English,
                PhoneNumbers = new string[]{ "999999", "8888888" }
            };
        }

        public static  Domain.StaffUser.Role build_instance_with(IEnumerable<Action< Domain.StaffUser.Role>> invalidations)
        {
            var extendedInfo = build_valid_instance();
            foreach(var invalidate in invalidations)
            {
                invalidate(extendedInfo);
            }
            return extendedInfo;
        }


        public static  Domain.StaffUser.Role build_instance_with(Action< Domain.StaffUser.Role> invalidate)
        {
            return build_instance_with(new Action< Domain.StaffUser.Role>[]{ invalidate });
        }
    }

    public class BasicRole : Domain.StaffUser.Role 
    {
        public BasicRole(Domain.StaffUser.RoleType type) : base(type)
        {
        }
    }
}

