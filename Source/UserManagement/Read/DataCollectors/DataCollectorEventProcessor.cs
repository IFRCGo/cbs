using System.Collections.Generic;
using Concepts;
using Concepts.DataCollectors;
using Dolittle.Events.Processing;
using Events.DataCollector;
using Events.VolunteerReporting;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents 
    {
        private readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("eac98aa0-b429-47c3-9097-e68bd54adb10")]
        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.Insert(new DataCollector()
            {
                Id = @event.DataCollectorId,
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
        [EventProcessor("50631704-fa1e-44d6-b35c-d71fb750d2f8")]
        public void Process(DataCollectorUserInformationChanged @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId, Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, @event.FullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, @event.DisplayName),
                    Builders<DataCollector>.Update.Set(d => d.Sex, (Sex) @event.Sex),
                    Builders<DataCollector>.Update.Set(d => d.YearOfBirth, @event.YearOfBirth),
                    Builders<DataCollector>.Update.Set(d => d.District, @event.District),
                    Builders<DataCollector>.Update.Set(d => d.Region, @event.Region))
                    );
            
        }
        [EventProcessor("6d09763d-30c4-45fd-be82-da5f1dfd6ed0")]
        public void Process(DataCollectorLocationChanged @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(@event.LocationLatitude,@event.LocationLongitude)));

        }
        [EventProcessor("c9d24ec7-8788-4b45-857f-5f1d034dbaaf")]
        public void Process(DataCollectorPreferredLanguageChanged @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.PreferredLanguage, (Language)@event.Language));
            
        }
        [EventProcessor("ba24c6a3-ff6a-413d-8505-45dadc587187")]
        public void Process(DataCollectorVillageChanged @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village));
        }
        [EventProcessor("32689875-b7e9-419e-b852-f78db6707d58")]
        public void Process(DataCollectorRemoved @event)
        {
            _dataCollectors.Delete(d => d.Id == (DataCollectorId)@event.DataCollectorId);
        }
        [EventProcessor("1b40d894-2304-49ce-b630-9dffec733cc1")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, new PhoneNumber(@event.PhoneNumber)));
            
        }
        [EventProcessor("70edb6fb-dae6-4019-96bd-022c89597ea8")]
        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn.Value == @event.PhoneNumber));
            
        }
        [EventProcessor("2426cf91-a2e9-4c5e-b891-ba30c4250b0c")]
        public void Process(CaseReportReceived @event)
        {
            // TODO:
            // _dataCollectors.Update(d => d.Id ==  (DataCollectorId)@event.DataCollectorId,
            //     Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
            
        }
        [EventProcessor("8742b038-f271-4183-aa95-6245239a16f0")]
        public void Process(InvalidReportReceived @event)
        {
            // TODO:
            // _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
            //     Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
        }

        [EventProcessor("fde6dd03-d4ad-4d90-99a9-faf20fca0521")]
        public void Process(DataCollectorBeganTraining @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.InTraining, true));
        }

        [EventProcessor("ec986665-1a59-43a0-aa88-f4e7f749ffda")]
        public void Process(DataCollectorCompletedTraining @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.InTraining, false));
        }

        [EventProcessor("cfd0bcf3-e490-492d-b14c-f992fa9fd59b")]
        public void Process(DataCollectorDataVerifierChanged @event)
        {
            _dataCollectors.Update(d => d.Id == (DataCollectorId)@event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.DataVerifier, @event.DataVerifierId));
        }
    }
}
