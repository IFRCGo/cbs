using System;

namespace Domain.DataCollectors.Registration
{
    public class DataCollectorAlreadyRegistered : Exception
    {
        public DataCollectorAlreadyRegistered(string message) : base(message)
        {
        }
    }
}