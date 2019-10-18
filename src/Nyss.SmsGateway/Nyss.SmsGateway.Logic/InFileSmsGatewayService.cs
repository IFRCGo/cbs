using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nyss.SmsGateway.Logic.Models;

namespace Nyss.SmsGateway.Logic
{
    public class InFileSmsGatewayService : ISmsGatewayService
    {
        public async Task<ValidationResult> SaveReportAsync(Sms sms)
        {
            if (sms == null) throw new ArgumentNullException(nameof(sms), "Sms informations are required.");

            var result = sms.Validate();

            if (result.IsValid)
            {
                using (var file = new StreamWriter(@"C:\temp\Nyss-sms.txt", true))
                {
                    var json = JsonConvert.SerializeObject(sms);
                    await file.WriteLineAsync(json);
                }
            }

            return result;
        }
    }
}
