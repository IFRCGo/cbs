using System;
using System.Threading.Tasks;
using Nyss.Data.Models;
using Nyss.SmsGateway.Data;
using Nyss.SmsGateway.Logic.Models;

namespace Nyss.SmsGateway.Logic
{
    public class SmsGatewayService : ISmsGatewayService
    {
        private readonly ISmsGatewayRepository _smsGatewayRepository;

        public SmsGatewayService(ISmsGatewayRepository smsGatewayRepository)
        {
            _smsGatewayRepository = smsGatewayRepository;
        }

        public async Task<ValidationResult> SaveReportAsync(Sms sms)
        {
            if (sms == null) throw new ArgumentNullException(nameof(sms), "Sms informations are required.");

            var result = sms.Validate();

            if (result.IsValid)
            {
                var dataCollector = await _smsGatewayRepository.GetDataCollectorFromPhoneNumberAsync(sms.Sender);

                var report = new Report
                {
                    CreatedAt = DateTime.Now,
                    DataCollector = dataCollector,
                    Location = sms.Location,
                    ReceivedAt = sms.ReceivedAt,
                    IsTraining = false,
                    
                    // TODO  
                };

                await _smsGatewayRepository.InsertReportAsync(report);
                await _smsGatewayRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}