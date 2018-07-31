/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events.External;
using Dolittle.Events.Processing;
using MongoDB.Driver;
using Concepts.DataCollector;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents
    {
        private readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.SaveDataCollector(
                @event.DataCollectorId,
                @event.FullName,
                @event.DisplayName,
                @event.LocationLatitude,
                @event.LocationLongitude,
                @event.Region,
                @event.District);
        }
        public void Process(DataCollectorUserInformationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeUserInformation(
                @event.DataCollectorId, 
                @event.FullName, 
                @event.DisplayName,
                @event.Region,
                @event.District);
        }
        public void Process(DataCollectorLocationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeLocation(
                @event.DataCollectorId, 
                @event.LocationLatitude,
                @event.LocationLongitude);
        }

        public void Process(DataCollectorVillageChanged @event)
        {
            
            var updateRes = _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village ?? "Unknown"));
        }

        //TODO: Is this something that makes sense, should we be able to remove a datacollector from VR?
        public void Process(DataCollectorRemoved @event)
        {
            var deleteRes = _dataCollectors.Delete(d => d.Id == (DataCollectorId)@event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var updateRes = _dataCollectors.AddPhoneNumber(d => d.Id == (DataCollectorId)@event.DataCollectorId, @event.PhoneNumber);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var updateRes = _dataCollectors.RemovePhoneNumber(d => d.Id == (DataCollectorId)@event.DataCollectorId, @event.PhoneNumber);
        }
    }
}