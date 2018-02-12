using System;
using System.Collections.Generic;
using Concepts;
using Events;

namespace Read.GreetingGenerators
{
    public class GreetingHistory{
        public Guid Id { get; set; }        
       
        public string PhoneNumber { get; set; }
        
        public GreetingHistory(Guid id) {
            Id = id;
        }       
    }
}
