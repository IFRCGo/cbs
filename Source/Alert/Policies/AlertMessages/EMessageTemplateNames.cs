namespace Policies.AlertMessages
{
    public enum EMessageTemplateNames
    {
        AlertRaisedFeedbackToDataCollectors,
        AlertRaisedFeedbackToDataVerifiers
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