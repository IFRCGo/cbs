/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Concepts.DataCollectors;
using Events.Management.DataCollectors.Registration;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Events.Management.DataCollectors.EditInformation;

namespace Read.Reporting.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<DataCollector_> _dataCollectors;

        public DataCollectorEventProcessor(IReadModelRepositoryFor<DataCollector_> dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("e5772c2d-2891-4abe-ac62-1adadc353f9b")]
        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.Insert(new DataCollector_(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName,
                FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth,
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>(),
                District = @event.District,
                Region = @event.Region           
            });
        }
        [EventProcessor("4075fedc-1167-4be7-8b87-32d5d00b3802")]
        public void Process(DataCollectorUserInformationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Sex = (Sex) @event.Sex;
            dataCollector.YearOfBirth = @event.YearOfBirth;
            dataCollector.District = @event.District;
            dataCollector.Region = @event.Region;

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("894563de-2ec4-43b7-8278-4e747beb479a")]
        public void Process(DataCollectorLocationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("81db77e9-8bce-4e07-b5d3-79f567689d7a")]
        public void Process(DataCollectorPreferredLanguageChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PreferredLanguage = (Language)@event.Language;
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("267c49a8-63af-459f-9f4e-dc262de4145f")]
        public void Process(DataCollectorVillageChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Village = @event.Village;
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("90dd0dff-448e-4def-9f21-40707b489345")]
        public void Process(DataCollectorRemoved @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            _dataCollectors.Delete(dataCollector);
        }
        [EventProcessor("50e8f518-2121-4b2a-869e-3d60119244d7")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Append(new PhoneNumber(@event.PhoneNumber));
            _dataCollectors.Update(dataCollector);            
        }
        [EventProcessor("b78408e8-bf7a-45a8-935a-a50f14cba7e0")]
        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers = dataCollector.PhoneNumbers.Where(u => u.Value != @event.PhoneNumber).ToList();
            _dataCollectors.Update(dataCollector);
        }
    }
}