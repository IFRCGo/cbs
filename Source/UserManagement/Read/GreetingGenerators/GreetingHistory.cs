using System;

namespace Read.GreetingGenerators
{
    public class GreetingHistory{
        public Guid Id { get; set; } //QUESTION: einari, michael: What does this represent? An EventSourceId or the StaffUserId of the datacollector?

        public string PhoneNumber { get; set; }
        
        public GreetingHistory(Guid id) {
            Id = id;
        }       
    }
}
