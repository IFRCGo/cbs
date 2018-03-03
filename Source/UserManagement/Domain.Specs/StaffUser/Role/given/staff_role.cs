using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.Role.given
{
    public class staff_role
    {
        public static Domain.StaffUser.StaffRole build_valid_instance()
        {
            return new BasicStaffRole
            {
                YearOfBirth = null,
                Sex = null,
                NationalSociety = Guid.NewGuid(),
                PreferredLanguage = Language.English,
                PhoneNumbers = new string[]{ "999999", "8888888" }
            };
        }

        public static  Domain.StaffUser.StaffRole build_instance_with(IEnumerable<Action< Domain.StaffUser.StaffRole>> invalidations)
        {
            var extendedInfo = build_valid_instance();
            foreach(var invalidate in invalidations)
            {
                invalidate(extendedInfo);
            }
            return extendedInfo;
        }


        public static  Domain.StaffUser.StaffRole build_instance_with(Action< Domain.StaffUser.StaffRole> invalidate)
        {
            return build_instance_with(new Action< Domain.StaffUser.StaffRole>[]{ invalidate });
        }
    }

    public class BasicStaffRole : Domain.StaffUser.StaffRole
    {
        public BasicStaffRole() : base(Domain.StaffUser.RoleType.DataCooridinator)
        {

        }
    }
}

