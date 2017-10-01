using System;
using Policies.AlertMessages;

namespace Policies
{
    public class MessageTemplateService : IMessageTemplateService
    {
        public string ComposeMessage(EMessageTemplateNames templateName, Guid healthRiskId)
        {
            string result = string.Empty;
            switch (templateName)
            {
                case EMessageTemplateNames.AlertRaisedFeedbackToDataCollectors:
                    result =
                        "Your [event] report(s) has triggered an alert. [Escalation UID], phone number: [phone number] will contact you for follow up. You need to [Key action].";
                    break;
                case EMessageTemplateNames.AlertRaisedFeedbackToDataVerifiers:
                    result = "[Health Risk] has triggered an alert. Please follow up with: [FullName] [Phone] (repeating). (Requires form attachment).";
                    break;
                default:
                    break;
            }
            return result;
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
