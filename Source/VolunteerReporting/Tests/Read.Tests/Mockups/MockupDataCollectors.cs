using System;
using System.Collections.Generic;

namespace Read.Tests.Mockups
{
    internal class MockupDataCollectors : IDataCollectors
    {
        public DataCollector GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public DataCollector GetByPhoneNumber(string phoneNumber)
        {
            return new DataCollector(Guid.NewGuid()) { PhoneNumbers = new List<string>() { phoneNumber } };
        }

        public void Save(DataCollector dataCollector)
        {
            throw new NotImplementedException();
        }
    }
}