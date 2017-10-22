using System.Collections.Generic;
using System.Linq;
using Events;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Read.Disease;
using Policies.AlertMessages;

namespace Policies
{
    public class AlertFeedbackService : IAlertFeedbackService
    {
        public static readonly Feature Feature = "Alert";

        private readonly ISmsSendingService _smsSendingService;
        private readonly IDataCollectors _dataCollectors;
        private readonly IEventEmitter _eventEmitter;
        private readonly IMessageTemplateService _messageTemplateService;

        public AlertFeedbackService(ISmsSendingService smsSendingService, IDataCollectors dataCollectors, IEventEmitter eventEmitter, IMessageTemplateService messageTemplateService)
        {
            _smsSendingService = smsSendingService;
            _dataCollectors = dataCollectors;
            _eventEmitter = eventEmitter;
            _messageTemplateService = messageTemplateService;
        }

        public void SendFeedbackToDataCollecorsAndVerifiers(IEnumerable<CaseReport> latestReports)
        {
            var dataCollectors = _dataCollectors.Get(latestReports.Select(o => o.DataCollectorId).ToArray());
            var collectors = dataCollectors as DataCollector[] ?? dataCollectors.ToArray();
            var dataVerifiers = collectors.GroupBy(o => o.DataVerifier.UserId).Select(o => o.First().DataVerifier).ToArray();
            var healthRisk = latestReports.First().HealthRiskId;

            // send sms to all data verifiers
            foreach (DataVerifier dataVerifier in dataVerifiers)
            {
                string text = _messageTemplateService.ComposeMessage(EMessageTemplateNames.AlertRaisedFeedbackToDataVerifiers, healthRisk);
                _smsSendingService.SendSMS(new [] { dataVerifier.Phone }, "");
                _eventEmitter.Emit(Feature, new SmsSentEvent() { RecipientName = dataVerifier.Name, RecipientPhoneNumber = dataVerifier.Phone, SmsText = text});
            }

            // send sms to all data collecors
            foreach (DataCollector dataCollector in collectors)
            {
                string text = _messageTemplateService.ComposeMessage(EMessageTemplateNames.AlertRaisedFeedbackToDataCollectors, healthRisk);
                _smsSendingService.SendSMS(new[] { dataCollector.Phone }, "");
                _eventEmitter.Emit(Feature, new SmsSentEvent() { RecipientName = dataCollector.Name, RecipientPhoneNumber = dataCollector.Phone, SmsText = text });
            }
        }
    }

    /*
     * 
     * Trigger escalation due to threshold 	
     * message to data collectors triggered
     * "Your [event] report(s) has triggered an alert. [Escalation UID], phone number: [phone number] will contact you for follow up. You need to [Key action]." 	#54

Alert trigger by others 	"An alert for [event] has been triggered for [location]. [Escalation UID], phone number: [phone number] will contact you for follow up. Please [Key action]."
to all neighbours of all that reported
when it is confirmed

    message to data verifier 
    [Health Risk] has triggered an alert. Please follow up with: [FullName] [Phone] (repeating). (Requires form attachment).
    Full name phone of all data collectors that send reports
     * */
}