/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events.External;

namespace Read
{
    public class DataCollectorEventProcessor : Infrastructure.Events.IEventProcessor
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
            dataCollector.LocationLatitude = @event.LocationLatitude;
            dataCollector.LocationLongitude = @event.LocationLongitude;
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberAdded @event)
        {
            //TODO: How to handle if datacollector does not exist? SHould not occur since that mean error in event sequence
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Add(@event.PhoneNumber);            
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberRemoved @event)
        {
            //TODO: How to handle if datacollector does not exist? SHould not occur since that mean error in event sequence
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Remove(@event.PhoneNumber);
            _dataCollectors.Save(dataCollector);
        }
    }
}