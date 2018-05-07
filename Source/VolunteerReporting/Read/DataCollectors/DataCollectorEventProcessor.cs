/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events.External;
using Dolittle.Events.Processing;
using Concepts;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public void Process(DataCollectorRegistered @event)
        {           
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ?? new DataCollector(@event.DataCollectorId);
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.Region = @event.Region ?? "Unknown";
            dataCollector.District = @event.District ?? "Unknown";
            _dataCollectors.Save(dataCollector);
        }
        public void Process(DataCollectorUserInformationChanged @event)
        {
            _dataCollectors.ChangeUserInformation(@event.DataCollectorId, @event.FullName, @event.DisplayName, @event.Region ?? "Unknown", @event.District ?? "Unknown");
        }
        public void Process(DataCollectorLocationChanged @event)
        {
            _dataCollectors.Update(Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.Location,
                    new Location(@event.LocationLatitude, @event.LocationLongitude)));
        }

        public void Process(DataCollectorVillageChanged @event)
        {
            _dataCollectors.Update(Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village ?? "Unknown"));
        }

        //TODO: Is this something that makes sense, should we be able to remove a datacollector from VR?
        public void Process(DataCollectorRemoved @event)
        {
            _dataCollectors.Remove(d => d.Id == @event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            _dataCollectors.AddPhoneNumber(d => d.Id == @event.DataCollectorId, @event.PhoneNumber);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _dataCollectors.RemovePhoneNumber(d => d.Id == @event.DataCollectorId, @event.PhoneNumber);
        }
    }
}