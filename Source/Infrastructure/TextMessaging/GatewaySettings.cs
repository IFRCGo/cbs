using System;
using Microsoft.Azure.ServiceBus;

namespace Infrastructure.TextMessaging
{
    public class GatewaySettings
    {
        /// <summary>
        /// Connection to the CBSs Azure Service Bus
        /// </summary>
        public string ServieBusConnectionString { get; set; } = "Endpoint=sb://cbs-sms-reporting-westeurope.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9zftqhnMA7vaiec428EnJ5+q0tvZC369+brP2djhKjM=";

        /// <summary>
        /// Name of the service. Will also be used as the listening subscription for the <see cref="ListenToTopic"/>
        /// </summary>
        public string ServiceName { get; set; } = "test"; // options: "admin", "alerts", "portal", "reporting", "test", "usermgmt", "volunteer"

        /// <summary>
        /// Queue where the SMS message will be added
        /// </summary>
        public string SendQueueName { get; set; } = "outgoing";

        /// <summary>
        /// Main topic where to listen for SMS messages. Subscription will be <see cref="ServiceName"/>
        /// </summary>
        public string ListenToTopic { get; set; } = "incomming"; 
    }
}
