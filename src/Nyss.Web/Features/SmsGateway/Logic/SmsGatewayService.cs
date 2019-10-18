using System;
using System.Threading.Tasks;
using Nyss.Data.Concepts;
using Nyss.Web.Features.Report.Data;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
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
                //var dataCollector = await _dataCollectorsService.GetDataCollectorFromPhoneNumberAsync(sms.Sender);

                var report = new Data.Models.Report
                {
                    CreatedAt = DateTime.Now,
                    //DataCollector = dataCollector,
                    Location = sms.Location,
                    ReceivedAt = sms.ReceivedAt,
                    IsTraining = false,
                    RawContent = sms.Text,
                    Status = ReportStatus.Pending,
                    // TODO  
                };

                await _reportRepository.InsertReportAsync(report);
                await _reportRepository.SaveChangesAsync();
            }

            return result;
        }
    }
}