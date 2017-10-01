using System.Collections.Generic;

namespace Policies
{
    public class SmsSendingServiceStub : ISmsSendingService
    {
        public void SendSMS(IEnumerable<string> phones, string message)
        {
            
        }
    }
}