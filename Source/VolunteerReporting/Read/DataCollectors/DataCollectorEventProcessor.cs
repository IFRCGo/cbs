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
            _dataCollectors.SaveDataCollector(
                @event.DataCollectorId,
                @event.FullName,
                @event.DisplayName,
                @event.LocationLatitude,
                @event.LocationLongitude);
        }
        public void Process(DataCollectorUserInformationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeUserInformation(
                @event.DataCollectorId, 
                @event.FullName, 
                @event.DisplayName);
        }
        public void Process(DataCollectorLocationChanged @event)
        {
            var updateRes = _dataCollectors.ChangeLocation(
                @event.DataCollectorId, 
                @event.LocationLatitude,
                @event.LocationLongitude);
        }
        
        public void Process(DataCollectorRemoved @event)
        {
            var deleteRes = _dataCollectors.DeleteOne(d => d.Id == @event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var updateRes = _dataCollectors.AddPhoneNumber(d => d.Id == @event.DataCollectorId, @event.PhoneNumber);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var updateRes = _dataCollectors.RemovePhoneNumber(d => d.Id == @event.DataCollectorId, @event.PhoneNumber);
        }
    }
}