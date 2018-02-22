using System;
using Concepts;

namespace Domain.MessageGenerators
{
    public class GenerateMessage
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}