using System;
using System.Threading.Tasks;
using Nyss.Data;
using Nyss.Web.Features.DataCollectors;
using Nyss.Web.Features.Report;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public class SmsGatewayService : ISmsGatewayService
    {
        private readonly IReportService _reportService;
        private readonly IDataCollectorsService _dataCollectorsService;

        public SmsGatewayService(IReportService reportService,
            IDataCollectorsService dataCollectorsService)
        {
            _reportService = reportService;
            _dataCollectorsService = dataCollectorsService;
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
                    //ReceivedAt = sms.ReceivedAt,
                    
                    // TODO  
                };

                await _reportService.InsertReportAsync(report);
                await _reportService.SaveChangesAsync();
            }

            return result;
        }
    }
}