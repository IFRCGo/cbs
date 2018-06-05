using System;
using Dolittle.ReadModels;

namespace Read.GreetingGenerators
{
    public class GreetingHistory : IReadModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        //TODO: Shouldn't this contain a string Message aswell? Or should there just be a default message?
        
        public GreetingHistory(Guid id) {
            Id = id;
        }       
    }
}
