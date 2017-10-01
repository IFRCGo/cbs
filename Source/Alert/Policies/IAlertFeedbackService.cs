using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Infrastructure.Application;
using Infrastructure.Events;
using Policies;
using Read;
using Read.Disease;

namespace Domain
{
    public interface IAlertFeedbackService
    {
        void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports);
    }

    public class AlertFeedbackService
    {
        public static readonly Feature Feature = "Alert";

        private readonly ISmsSendingService _smsSendingService;
        private readonly IDataCollectors _dataCollectors;
        private readonly IEventEmitter _eventEmitter;

        public AlertFeedbackService(ISmsSendingService smsSendingService, IDataCollectors dataCollectors, IEventEmitter eventEmitter)
        {
            _smsSendingService = smsSendingService;
            _dataCollectors = dataCollectors;
            _eventEmitter = eventEmitter;
        }
        public void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports)
        {
            var dataCollectors = _dataCollectors.Get(latestReports.Select(o => o.DataCollectorId).ToArray());
            var dataVerifiers = dataCollectors.GroupBy(o => o.DataVerifier.UserId).Select(o => o.First().DataVerifier).ToArray();

            // send sms to all data verifiers
            foreach (DataVerifier dataVerifier in dataVerifiers)
            {
                string text = "";
                _smsSendingService.SendSMS(new [] { dataVerifier.Phone }, "");
                _eventEmitter.Emit(Feature, new SmsSentEvent() { RecipientName = dataVerifier.Name, RecipientPhoneNumber = dataVerifier.Phone, SmsText = text});
            }

            // send sms to all data collecors
            foreach (DataCollector dataCollector in dataCollectors)
            {
                string text = "";
                _smsSendingService.SendSMS(new[] { dataCollector.Phone }, "");
                _eventEmitter.Emit(Feature, new SmsSentEvent() { RecipientName = dataCollector.Name, RecipientPhoneNumber = dataCollector.Phone, SmsText = text });
            }
        }
    }
}
