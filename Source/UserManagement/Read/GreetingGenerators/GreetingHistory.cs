using System;
using doLittle.Read;

namespace Read.GreetingGenerators
{
    public class GreetingHistory : IReadModel
    {
        public Guid GreetingHistoryId { get; set; }
        public string PhoneNumber { get; set; }
        //TODO: Shouldn't this contain a string Message aswell? Or should there just be a default message?
        
        public GreetingHistory(Guid greetingHistoryId) {
            GreetingHistoryId = greetingHistoryId;
        }       
    }
}
