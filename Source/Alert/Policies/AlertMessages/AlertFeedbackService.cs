using System.Collections.Generic;
using System.Linq;
using Events;
using doLittle.Events;
using Read;
using Read.Disease;
using Policies.AlertMessages;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Events;
using doLittle.Runtime.Transactions;

namespace Policies
{
    public class AlertFeedbackService : IAlertFeedbackService
    {
        private readonly ISmsSendingService _smsSendingService;
        private readonly IDataCollectors _dataCollectors;
        private readonly IMessageTemplateService _messageTemplateService;
        private readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;

        public AlertFeedbackService(ISmsSendingService smsSendingService, IDataCollectors dataCollectors, IMessageTemplateService messageTemplateService, IUncommittedEventStreamCoordinator uncommittedEventStreamCoordinator)
        {
            _smsSendingService = smsSendingService;
            _dataCollectors = dataCollectors;
            _uncommittedEventStreamCoordinator = uncommittedEventStreamCoordinator;
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
                ApplyEvent(new SmsSentEvent() { RecipientName = dataVerifier.Name, RecipientPhoneNumber = dataVerifier.Phone, SmsText = text});
            }

            // send sms to all data collecors
            foreach (DataCollector dataCollector in collectors)
            {
                string text = _messageTemplateService.ComposeMessage(EMessageTemplateNames.AlertRaisedFeedbackToDataCollectors, healthRisk);
                _smsSendingService.SendSMS(new[] { dataCollector.Phone }, "");
                ApplyEvent(new SmsSentEvent() { RecipientName = dataCollector.Name, RecipientPhoneNumber = dataCollector.Phone, SmsText = text });
            }
        }


        void ApplyEvent(IEvent @event)
        {
            // Todo: Temporary fix - we're not supposed to do this, awaiting the new Policy building block in doLittle to be ready
            var stream = new UncommittedEventStream(null);
            stream.Append(@event, EventSourceVersion.Zero.NextCommit());
            _uncommittedEventStreamCoordinator.Commit(TransactionCorrelationId.New(), stream);
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