using System;
using System.Collections.Generic;
using System.Text;

namespace Policies
{
    public interface ISmsSendingService
    {
        void SendSMS(IEnumerable<string> phones, string message);
    }
}
