using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public class InFileSmsGatewayService : ISmsGatewayService
    {
        private readonly ISmsParser _smsParser;

        public InFileSmsGatewayService(ISmsParser smsParser)
        {
            _smsParser = smsParser;
        }
        
        public async Task<SmsProcessResult> SaveReportAsync(Sms sms)
        {
            if (sms == null) throw new ArgumentNullException(nameof(sms), "Sms informations are required.");

            var result = sms.Validate();

            if (result.IsRequestValid)
            {
                using (var file = new StreamWriter(@"C:\temp\Nyss-sms.txt", true))
                {
                    var json = JsonConvert.SerializeObject(sms);
                    await file.WriteLineAsync(json);
                }
                
                var parsedCase = _smsParser.ParseSmsToCase(sms.Text);

                if (parsedCase.IsValid)
                {
                    result.ResponseMessage = "Yay ! Thank you bro";
                }
                else
                {
                    result.ResponseMessage = "Sorry bro, I do not understand.";
                }
            }
            
            return await Task.FromResult(result);
        }
    }
}
