/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Concepts.DataCollector;
using Events.DataCollectors.Registration;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Events.DataCollectors.Changing;
using Events.DataCollectors.PhoneNumber;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;

        public DataCollectorEventProcessor(IReadModelRepositoryFor<DataCollector> dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("eac98aa0-b429-47c3-9097-e68bd54adb10")]
        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.Insert(new DataCollector(@event.DataCollectorId)
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
                //TODO: Village as well?                
            });
        }
        [EventProcessor("50631704-fa1e-44d6-b35c-d71fb750d2f8")]
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
        [EventProcessor("6d09763d-30c4-45fd-be82-da5f1dfd6ed0")]
        public void Process(DataCollectorLocationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("c9d24ec7-8788-4b45-857f-5f1d034dbaaf")]
        public void Process(DataCollectorPreferredLanguageChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PreferredLanguage = (Language)@event.Language;
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("ba24c6a3-ff6a-413d-8505-45dadc587187")]
        public void Process(DataCollectorVillageChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.Village = @event.Village;
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("32689875-b7e9-419e-b852-f78db6707d58")]
        public void Process(DataCollectorRemoved @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            _dataCollectors.Delete(dataCollector);
        }
        [EventProcessor("1b40d894-2304-49ce-b630-9dffec733cc1")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Append(new PhoneNumber() { Value = @event.PhoneNumber });
            _dataCollectors.Update(dataCollector);            
        }
        [EventProcessor("70edb6fb-dae6-4019-96bd-022c89597ea8")]
        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers = dataCollector.PhoneNumbers.Where(u => u.Value != @event.PhoneNumber).ToList();
            _dataCollectors.Update(dataCollector);
        }
    }
}