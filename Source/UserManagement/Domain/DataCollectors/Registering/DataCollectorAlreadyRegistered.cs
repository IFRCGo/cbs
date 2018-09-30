using System;

namespace Domain.DataCollectors.Registering
{
    public class DataCollectorAlreadyRegistered : Exception
    {
        public DataCollectorAlreadyRegistered(string message) : base(message)
        {
        }
    }
}