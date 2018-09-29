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
        [EventProcessor("8229d334-7cdb-4306-a1ca-2035b5cf01fb")]
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
        [EventProcessor("c646722d-6c59-4c83-8e64-df07687dc201")]
        public void Process(DataCollectorUserInformationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeUserInformation(
                @event.DataCollectorId, 
                @event.FullName, 
                @event.DisplayName,
                @event.Region,
                @event.District);
        }
        [EventProcessor("2ec3dfda-69d0-4d84-a9a8-1a4407e29422")]
        public void Process(DataCollectorLocationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeLocation(
                @event.DataCollectorId, 
                @event.LocationLatitude,
                @event.LocationLongitude);
        }
        [EventProcessor("20b91669-4ecf-436c-9b17-41b28035cba8")]
        public void Process(DataCollectorVillageChanged @event)
        {
            
            var updateRes = _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village ?? "Unknown"));
        }

        //TODO: Is this something that makes sense, should we be able to remove a datacollector from VR?
        [EventProcessor("739df653-981f-42cb-8e7a-80c96f52873d")]
        public void Process(DataCollectorRemoved @event)
        {
            var deleteRes = _dataCollectors.Delete(d => d.Id == (DataCollectorId)@event.DataCollectorId);
        }
        [EventProcessor("61804c49-996e-4cd8-b498-16824f6369ea")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var updateRes = _dataCollectors.AddPhoneNumber(d => d.Id == (DataCollectorId)@event.DataCollectorId, @event.PhoneNumber);
        }
        [EventProcessor("7abc902a-fcde-4089-898e-8b9b98229c32")]
        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var updateRes = _dataCollectors.RemovePhoneNumber(d => d.Id == (DataCollectorId)@event.DataCollectorId, @event.PhoneNumber);
        }
    }
}