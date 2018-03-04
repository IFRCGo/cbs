using System.Collections.Generic;
using System;

namespace Domain.StaffUser
{
    public interface IRequirePhoneNumbers
    {
         IEnumerable<string> PhoneNumbers { get; }
    }
}