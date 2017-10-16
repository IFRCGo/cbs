/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Read.HealthRiskFeatures;
using System;

namespace Web.Features.CaseReportReceptionFeatures
{
    //TODO: Is the web project the right places for this? Processing the TextMessageReceived event is kinda like a command, and an event is only emited if its a valid message
    public class TextMessageRecievedEventProcessor : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReportReception";
        private readonly IEventEmitter _eventEmitter;
        private readonly IDataCollectors _dataCollectors;
        private readonly IHealthRisks _healthRisks;

        public TextMessageRecievedEventProcessor(
            IEventEmitter eventEmitter,
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks)
        {
            _eventEmitter = eventEmitter;
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
        }

        //TODO: Add a test that ensure that the right count is put in the right property
        //TODO: This should possibly be process once, since it should only happen the first time a text message is recieved
        public void Process(TextMessageReceived @event)
        {            
            var caseReportContent = TextMessageContentParser.Parse(@event.Message);            
            var dataCollector = _dataCollectors.GetByPhoneNumber(@event.OriginNumber);
            
            if(caseReportContent.GetType() == typeof(InvalidCaseReportContent))
            {
                //TODO: Handle if datacollector is unknown also. Different event?
                var invalidCaseReport = caseReportContent as InvalidCaseReportContent;
                _eventEmitter.Emit(Feature, new TextMessageParsingFailed
                {
                    Id = Guid.NewGuid(),
                    DataCollectorId = dataCollector.Id,
                    Message = @event.Message,
                    ParsingErrorMessage = invalidCaseReport.ErrorMessage
                });
            }
            else if (caseReportContent.GetType() == typeof(SingleCaseReportContent))
            {
                var singlecaseReport = caseReportContent as SingleCaseReportContent;
                var healthRisk = _healthRisks.GetByReadableId(singlecaseReport.HealthRiskId);
                if (dataCollector == null)
                {
                    _eventEmitter.Emit(Feature, new AnonymousCaseReportRecieved
                    {
                        Id = Guid.NewGuid(),
                        PhoneNumber = @event.OriginNumber,
                        HealthRiskId = healthRisk.Id,
                        NumberOfFemalesUnder5 =
                        singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                        NumberOfFemalesOver5 =
                        singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                        NumberOfMalesUnder5 =
                        singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                        NumberOfMalesOver5 =
                        singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                        Latitude = @event.Latitude,
                        Longitude = @event.Longitude,
                        Timestamp = @event.Sent
                    });
                    return;
                }
                _eventEmitter.Emit(Feature, new CaseReportReceived
                {
                    Id = Guid.NewGuid(),
                    DataCollectorId = dataCollector.Id,
                    HealthRiskId = healthRisk.Id,
                    NumberOfFemalesUnder5 = 
                    singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                    NumberOfFemalesOver5 =
                    singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                    NumberOfMalesUnder5 =
                    singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                    NumberOfMalesOver5 =
                    singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                    Latitude = @event.Latitude,
                    Longitude = @event.Longitude,
                    Timestamp = @event.Sent
                });
            }
            else
            {
                var report = caseReportContent as MultipleCaseReportContent;
                var healthRisk = _healthRisks.GetByReadableId(report.HealthRiskId);
                if (dataCollector == null)
                {
                    _eventEmitter.Emit(Feature, new AnonymousCaseReportRecieved
                    {
                        Id = Guid.NewGuid(),
                        PhoneNumber = @event.OriginNumber,
                        HealthRiskId = healthRisk.Id,
                        NumberOfFemalesUnder5 = report.FemalesUnder5,
                        NumberOfFemalesOver5 = report.FemalesOver5,
                        NumberOfMalesUnder5 = report.MalesUnder5,
                        NumberOfMalesOver5 = report.MalesOver5,
                        Latitude = @event.Latitude,
                        Longitude = @event.Longitude,
                        Timestamp = @event.Sent
                    });
                    return;
                }
                _eventEmitter.Emit(Feature, new CaseReportReceived
                {
                    Id = Guid.NewGuid(),
                    DataCollectorId = dataCollector.Id,
                    HealthRiskId = healthRisk.Id,
                    NumberOfFemalesUnder5 = report.FemalesUnder5,                    
                    NumberOfFemalesOver5 = report.FemalesOver5,
                    NumberOfMalesUnder5 = report.MalesUnder5,
                    NumberOfMalesOver5 = report.MalesOver5,
                    Latitude = @event.Latitude,
                    Longitude = @event.Longitude,
                    Timestamp = @event.Sent
                });
            }
        }        
    }    
}
