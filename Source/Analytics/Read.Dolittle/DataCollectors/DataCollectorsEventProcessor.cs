using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Events.Processing;
using Events.Reporting.DataCollectors;
using Read.DataCollectors;

namespace Read.Dolittle.DataCollectors
{
    public class DataCollectorsEventProcessor
    {
        private readonly IDataCollectorsEventHandler _dataCollectorsEventHandler;

        public DataCollectorsEventProcessor(IDataCollectorsEventHandler dataCollectorsEventHandler)
        {
            _dataCollectorsEventHandler = dataCollectorsEventHandler;
        }
        
        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(DataCollectorRegistered @event)
        {
            var dataCollector = new Read.DataCollectors.DataCollector(
                @event.DataCollectorId, @event.FullName, @event.DisplayName, @event.YearOfBirth, @event.Sex,
                @event.PreferredLanguage, @event.LocationLongitude, @event.LocationLatitude, @event.RegisteredAt, @event.Region, @event.District);

            _dataCollectorsEventHandler.Handle(dataCollector);
        }
    }
}
