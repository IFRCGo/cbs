using System;
using System.Collections.Generic;
using System.Text;

namespace Policies.Alerts
{
    public interface IMailSender
    {
        void Send(string emailTo, string subject, string textBody);
    }
}
