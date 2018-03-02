using System;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.BasicInfo.given
{
    public class basic_info
    {
        public static  Domain.StaffUser.BasicInfo build_valid_instance()
        {
            return new Domain.StaffUser.BasicInfo
            {
                StaffUserId = Guid.NewGuid(),
                Email = "user@redcross.no",
                FullName = "Our New User",
                DisplayName = "Joe"
            };
        }

        public static  Domain.StaffUser.BasicInfo build_instance_with(params Action< Domain.StaffUser.BasicInfo>[] invalidations)
        {
            var basicInfo = build_valid_instance();
            foreach(var invalidate in invalidations)
            {
                invalidate(basicInfo);
            }
            return basicInfo;
        }


        public static  Domain.StaffUser.BasicInfo build_instance_with(Action< Domain.StaffUser.BasicInfo> invalidate)
        {
            return build_instance_with(new Action< Domain.StaffUser.BasicInfo>[]{ invalidate });
        }
    }
}