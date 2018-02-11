/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events.External;
using doLittle.Events.Processing;
using Concepts;
using System.Threading.Tasks;

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
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            _dataCollectors.Save(dataCollector);
        }

        public async Task Process(PhoneNumberAddedToDataCollector @event)
        {
            //TODO: How to handle if datacollector does not exist? SHould not occur since that mean error in event sequence
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Add(@event.PhoneNumber);            
            await _dataCollectors.Save(dataCollector);
        }

        public async Task Process(PhoneNumberRemovedFromDataCollector @event)
        {
            //TODO: How to handle if datacollector does not exist? SHould not occur since that mean error in event sequence
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Remove(@event.PhoneNumber);
            await _dataCollectors.Save(dataCollector);
        }
    }
}