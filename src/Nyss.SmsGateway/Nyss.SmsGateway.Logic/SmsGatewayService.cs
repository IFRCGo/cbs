using System;
using System.Threading;
using System.Threading.Tasks;
using Nyss.Data.Models;
using Nyss.SmsGateway.Data;
using Nyss.SmsGateway.Logic.Models;

namespace Nyss.SmsGateway.Logic
{
    public class SmsGatewayService : ISmsGatewayService
    {
        private readonly IReportRepository _reportRepository;

        public SmsGatewayService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ValidationResult> SaveReportAsync(Sms sms)
        {
            if (sms == null) throw new ArgumentNullException(nameof(sms), "Sms informations are required.");

            var result = sms.Validate();

            if (result.IsValid)
            {
                var report = new Report
                {
                    CreatedAt = sms.TimestampDateTime,
                    // TODO  
                };

                await _reportRepository.InsertAsync(report);
                await _reportRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}
