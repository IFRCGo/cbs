using System;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.UserInfo.given
{
    public class user_info
    {
        public static  Domain.StaffUser.UserInfo build_valid_instance()
        {
            return new Domain.StaffUser.UserInfo
            {
                StaffUserId = Guid.NewGuid(),
                Email = "user@redcross.no",
                FullName = "Our New User",
                DisplayName = "Joe"
            };
        }

        public static  Domain.StaffUser.UserInfo build_instance_with(params Action< Domain.StaffUser.UserInfo>[] invalidations)
        {
            var basicInfo = build_valid_instance();
            foreach(var invalidate in invalidations)
            {
                invalidate(basicInfo);
            }
            return basicInfo;
        }

        public static  Domain.StaffUser.UserInfo build_instance_with(Action< Domain.StaffUser.UserInfo> invalidate)
        {
            return build_instance_with(new Action< Domain.StaffUser.UserInfo>[]{ invalidate });
        }
    }
}