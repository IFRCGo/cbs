using System.Collections.Generic;
namespace Domain.StaffUser
{
    public interface IRequirePhoneNumbers
    {
         IEnumerable<string> PhoneNumbers { get; }
    }
}