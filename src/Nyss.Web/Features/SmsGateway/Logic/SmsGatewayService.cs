using System;
using System.Threading.Tasks;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public class SmsGatewayService : ISmsGatewayService
    {
        private readonly ISmsParser _smsParser;

        public SmsGatewayService(ISmsParser smsParser)
        {
            _smsParser = smsParser;
        }

        public async Task<SmsProcessResult> SaveReportAsync(Sms sms)
        {
            if (sms == null) throw new ArgumentNullException(nameof(sms), "Sms informations are required.");

            var result = sms.Validate();
            result.PhoneNumber = sms.Sender;

            if (result.IsRequestValid)
            {
                var parsedCase = _smsParser.ParseSmsToCase(sms.Text);

                if (parsedCase.IsValid)
                {
                    result.FeedbackMessage = "Thank you";
                }
                else
                {
                    result.FeedbackMessage = "Sorry, I do not understand.";
                }
            }
            
            return await Task.FromResult(result);
        }
    }
}