/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.DataCollectors;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Management.DataCollectors.EditInformation;
using Events.Management.DataCollectors.Registration;
using Events.Management.DataCollectors.Training;
using Events.Reporting.CaseReports;

namespace Read.Management.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents 
    {
        private readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;

        public DataCollectorEventProcessor(IReadModelRepositoryFor<DataCollector> dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("eac98aa0-b429-47c3-9097-e68bd54adb10")]
        public void Process(DataCollectorRegistered @event, EventSourceId dataCollectorId)
        {
            _dataCollectors.Insert(new DataCollector()
            {
                Id = dataCollectorId.Value,
                DisplayName = @event.DisplayName,
                FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth,
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>(),
                District = @event.District,
                Region = @event.Region,
                DataVerifier = @event.DataVerifierId
            });
        }
        [EventProcessor("50631704-fa1e-44d6-b35c-d71fb750d2f8")]
        public void Process(DataCollectorUserInformationChanged @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Sex = (Sex) @event.Sex;
            dataCollector.YearOfBirth = @event.YearOfBirth;
            dataCollector.District = @event.District;
            dataCollector.Region = @event.Region;

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("6d09763d-30c4-45fd-be82-da5f1dfd6ed0")]
        public void Process(DataCollectorLocationChanged @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("c9d24ec7-8788-4b45-857f-5f1d034dbaaf")]
        public void Process(DataCollectorPreferredLanguageChanged @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.PreferredLanguage = (Language) @event.Language;

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("ba24c6a3-ff6a-413d-8505-45dadc587187")]
        public void Process(DataCollectorVillageChanged @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.Village = @event.Village;

            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("32689875-b7e9-419e-b852-f78db6707d58")]
        public void Process(DataCollectorRemoved @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            _dataCollectors.Delete(dataCollector);
        }
        [EventProcessor("1b40d894-2304-49ce-b630-9dffec733cc1")]
        public void Process(PhoneNumberAddedToDataCollector @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            var phoneNumbers = dataCollector.PhoneNumbers;
            phoneNumbers.Append(new PhoneNumber(){Value = @event.PhoneNumber});
            dataCollector.PhoneNumbers = phoneNumbers;
            _dataCollectors.Update(dataCollector);
        }
        [EventProcessor("70edb6fb-dae6-4019-96bd-022c89597ea8")]
        public void Process(PhoneNumberRemovedFromDataCollector @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            var phoneNumbers = dataCollector.PhoneNumbers.ToList();
            phoneNumbers.RemoveAll(_ => _.Value == @event.PhoneNumber);
            dataCollector.PhoneNumbers = phoneNumbers;
            _dataCollectors.Update(dataCollector);         
        }
        [EventProcessor("2426cf91-a2e9-4c5e-b891-ba30c4250b0c")]
        public void Process(CaseReportReceived @event, EventSourceId dataCollectorId)
        {
            // TODO:
            // _dataCollectors.Update(d => d.Id ==  (DataCollectorId)dataCollectorId,
            //     Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
            
        }
        [EventProcessor("8742b038-f271-4183-aa95-6245239a16f0")]
        public void Process(InvalidReportReceived @event, EventSourceId dataCollectorId)
        {
            // TODO:
            // _dataCollectors.Update(d => d.Id == (DataCollectorId)dataCollectorId,
            //     Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
        }

        [EventProcessor("fde6dd03-d4ad-4d90-99a9-faf20fca0521")]
        public void Process(DataCollectorBeganTraining @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.InTraining = true;

            _dataCollectors.Update(dataCollector);
        }

        [EventProcessor("ec986665-1a59-43a0-aa88-f4e7f749ffda")]
        public void Process(DataCollectorCompletedTraining @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.InTraining = false;

            _dataCollectors.Update(dataCollector);
        }

        [EventProcessor("cfd0bcf3-e490-492d-b14c-f992fa9fd59b")]
        public void Process(DataCollectorDataVerifierChanged @event, EventSourceId dataCollectorId)
        {
            var dataCollector = _dataCollectors.GetById(dataCollectorId.Value);
            dataCollector.DataVerifier = @event.DataVerifierId;

            _dataCollectors.Update(dataCollector);
        }
    }
}