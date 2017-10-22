/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using Read.HealthRiskFeatures;
using System;

namespace Read.TextMessageRecievedFeatures
{
    //TODO: Is the web project the right places for this? Processing the TextMessageReceived event is kinda like a command, and an event is only emited if its a valid message
    public class TextMessageRecievedRaiseCaseReportsEventsProcessor : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReportReception";

        private readonly IEventEmitter _eventEmitter;
        private readonly IDataCollectors _dataCollectors;
        private readonly IHealthRisks _healthRisks;

        public TextMessageRecievedRaiseCaseReportsEventsProcessor(
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

            switch (caseReportContent)
            {
                case InvalidCaseReportContent invalidCaseReport:
                    if (dataCollector != null)
                        EmitTextMessageParsingFailed(invalidCaseReport, dataCollector, @event);
                    break;

                case SingleCaseReportContent singleCaseReport:
                    if (dataCollector == null)
                        EmitAnonymousCaseReportReceived(singleCaseReport, @event);
                    else
                        EmitCaseReportReceived(singleCaseReport, dataCollector, @event);
                    break;

                case MultipleCaseReportContent multiCaseReport:
                    if (dataCollector == null)
                        EmitAnonymousCaseReportReceived(multiCaseReport, @event);
                    else
                        EmitCaseReportReceived(multiCaseReport, dataCollector, @event);
                    break;
            }
        }

        private void EmitCaseReportReceived(MultipleCaseReportContent multiCaseReport, DataCollector dataCollector, TextMessageReceived @event)
        {
            var healthRisk = _healthRisks.GetByReadableId(multiCaseReport.HealthRiskId);
            _eventEmitter.Emit(Feature, new CaseReportReceived
            {
                Id = Guid.NewGuid(),
                DataCollectorId = dataCollector.Id,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 = multiCaseReport.FemalesUnder5,
                NumberOfFemalesOver5 = multiCaseReport.FemalesOver5,
                NumberOfMalesUnder5 = multiCaseReport.MalesUnder5,
                NumberOfMalesOver5 = multiCaseReport.MalesOver5,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Sent
            });
        }

        private void EmitAnonymousCaseReportReceived(MultipleCaseReportContent report, TextMessageReceived @event)
        {
            var healthRisk = _healthRisks.GetByReadableId(report.HealthRiskId);
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
        }

        private void EmitCaseReportReceived(SingleCaseReportContent singleCaseReport, DataCollector dataCollector, TextMessageReceived @event)
        {
            var healthRisk = _healthRisks.GetByReadableId(singleCaseReport.HealthRiskId);
            _eventEmitter.Emit(Feature, new CaseReportReceived
            {
                Id = Guid.NewGuid(),
                DataCollectorId = dataCollector.Id,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfFemalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfMalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                NumberOfMalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Sent
            });
        }

        private void EmitAnonymousCaseReportReceived(SingleCaseReportContent singleCaseReport, TextMessageReceived @event)
        {
            var healthRisk = _healthRisks.GetByReadableId(singleCaseReport.HealthRiskId);
            _eventEmitter.Emit(Feature, new AnonymousCaseReportRecieved
            {
                Id = Guid.NewGuid(),
                PhoneNumber = @event.OriginNumber,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfFemalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfMalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                NumberOfMalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Sent
            });
        }

        private void EmitTextMessageParsingFailed(InvalidCaseReportContent invalidCaseReport, DataCollector dataCollector, TextMessageReceived @event)
        {
            _eventEmitter.Emit(Feature, new TextMessageParsingFailed
            {
                Id = Guid.NewGuid(),
                DataCollectorId = dataCollector.Id,
                Message = @event.Message,
                ParsingErrorMessage = invalidCaseReport.ErrorMessage
            });
        }
    }
}
