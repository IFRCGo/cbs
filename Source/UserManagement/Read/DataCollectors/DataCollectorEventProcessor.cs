using Concepts;
using doLittle.Events.Processing;
using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents 
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public void Process(DataCollectorAdded @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.Id) ?? new DataCollector(@event.Id);
            dataCollector.FirstName = @event.FirstName;
            dataCollector.LastName = @event.LastName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.Age = @event.Age;
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = @event.PreferredLanguage;
            dataCollector.Sex = @event.Sex;
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Add(@event.PhoneNumber);
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Remove(@event.PhoneNumber);
            _dataCollectors.Save(dataCollector);
        }
    }
}
