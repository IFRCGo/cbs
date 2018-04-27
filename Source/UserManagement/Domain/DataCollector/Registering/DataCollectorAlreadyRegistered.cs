using System;

namespace Domain.DataCollector.Registering
{
    public class DataCollectorAlreadyRegistered : Exception
    {
        public DataCollectorAlreadyRegistered(string message) : base(message)
        {
        }
    }
}