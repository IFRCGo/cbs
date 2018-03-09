using System;

namespace Read.StaffUsers
{
    public class UserNotOfExpectedType : Exception
    {
        public UserNotOfExpectedType(string msg) : base(msg)
        {

        }
    }
}