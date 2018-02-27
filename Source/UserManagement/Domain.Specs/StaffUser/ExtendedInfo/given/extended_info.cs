using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.ExtendedInfo.given
{
    public class extended_info
    {
        public static  Domain.StaffUser.ExtendedInfo build_valid_instance()
        {
            return new Domain.StaffUser.ExtendedInfo
            {
                //Location = new Location(45,45),
                YearOfBirth = null,
                Sex = null,
                NationalSociety = Guid.NewGuid(),
                PreferredLanguage = Language.English,
                PhoneNumbers = new string[]{ "999999" }
            };
        }

        public static  Domain.StaffUser.ExtendedInfo build_instance_with(IEnumerable<Action< Domain.StaffUser.ExtendedInfo>> invalidations)
        {
            var extendedInfo = build_valid_instance();
            foreach(var invalidate in invalidations)
            {
                invalidate(extendedInfo);
            }
            return extendedInfo;
        }


        public static  Domain.StaffUser.ExtendedInfo build_instance_with(Action< Domain.StaffUser.ExtendedInfo> invalidate)
        {
            return build_instance_with(new Action< Domain.StaffUser.ExtendedInfo>[]{ invalidate });
        }
    }
}

