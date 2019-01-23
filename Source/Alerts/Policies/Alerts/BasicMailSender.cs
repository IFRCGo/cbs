using System;
using System.Net;
using System.Net.Mail;

namespace Policies.Alerts
{
    public class BasicMailSender : IMailSender
    {
        private readonly string _from;
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;
        private readonly int _smtpPort;
        private bool _useSsl;

        public BasicMailSender()
        {
            this._from = Environment.GetEnvironmentVariable("ALERT_MAILER_FROM");
            this._host = Environment.GetEnvironmentVariable("ALERT_MAILER_HOST");
            this._user = Environment.GetEnvironmentVariable("ALERT_MAILER_USER");
            this._password = Environment.GetEnvironmentVariable("ALERT_MAILER_PASSWORD");

            int port = 25;
            int.TryParse(Environment.GetEnvironmentVariable("ALERT_MAILER_PORT"), out port);
            this._smtpPort = port;

            bool useSsl = false;
            bool.TryParse(Environment.GetEnvironmentVariable("ALERT_MAILER_USESSL"), out useSsl);
            this._useSsl = useSsl;
        }

        public void Send(string emailTo, string subject, string textBody)
        {
            using (MailMessage mail = new MailMessage(_from, emailTo))
            using (SmtpClient client = new SmtpClient())
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = _useSsl;
                client.Host = _host;
                client.Port = _smtpPort;
                client.Credentials = new NetworkCredential(_user, _password);
                mail.Subject = subject;
                mail.Body = textBody;
                client.Send(mail);
            }
        }
    }
}
