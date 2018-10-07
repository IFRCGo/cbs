using System;

namespace Domain.DataCollectors
{
    public class DataCollectorAlreadyRegistered : Exception
    {
        public DataCollectorAlreadyRegistered(string message) : base(message)
        {
        }
    }
}