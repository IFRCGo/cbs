/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Read.HealthRiskFeatures;
using Infrastructure.TextMessaging;
using Domain.TextMessages;
using Read;
using doLittle.Runtime.Events;
using doLittle.Events;

namespace Policies.TextMessages
{
    public class TextMessageProcessor : ICanProcessTextMessage
    {
        readonly IDataCollectors _dataCollectors;
        readonly IHealthRisks _healthRisks;
        readonly ITextMessageContentParser _textMessageContentParser;

        public TextMessageProcessor(
            IDataCollectors dataCollectors, 
            IHealthRisks healthRisks,
            ITextMessageContentParser textMessageContentParser)
        {
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
            _textMessageContentParser = textMessageContentParser;
        }

        public void Process(TextMessage message)
        {
            var caseReportContent = _textMessageContentParser.Parse(message.Message);
            var dataCollector = _dataCollectors.GetByPhoneNumber(message.OriginNumber);

            switch (caseReportContent)
            {
                case InvalidCaseReportContent invalidCaseReport:
                    if (dataCollector != null)
                        EmitTextMessageParsingFailed(invalidCaseReport, dataCollector, message);
                    break;

                case SingleCaseReportContent singleCaseReport:
                    if (dataCollector == null)
                        EmitAnonymousCaseReportReceived(singleCaseReport, message);
                    else
                        EmitCaseReportReceived(singleCaseReport, dataCollector, message);
                    break;

                case MultipleCaseReportContent multiCaseReport:
                    if (dataCollector == null)
                        EmitAnonymousCaseReportReceived(multiCaseReport, message);
                    else
                        EmitCaseReportReceived(multiCaseReport, dataCollector, message);
                    break;
            }
        }

        private void EmitCaseReportReceived(MultipleCaseReportContent multiCaseReport, DataCollector dataCollector, TextMessage message)
        {
            var healthRisk = _healthRisks.GetByReadableId(multiCaseReport.HealthRiskId);

            var eventSourceId = EventSourceId.New();

            Apply(eventSourceId, new CaseReportReceived
            {
                Id = eventSourceId,
                DataCollectorId = dataCollector.Id,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 = multiCaseReport.FemalesUnder5,
                NumberOfFemalesOver5 = multiCaseReport.FemalesOver5,
                NumberOfMalesUnder5 = multiCaseReport.MalesUnder5,
                NumberOfMalesOver5 = multiCaseReport.MalesOver5,
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Timestamp = message.Sent
            });
        }

        private void EmitAnonymousCaseReportReceived(MultipleCaseReportContent report, TextMessage message)
        {
            var healthRisk = _healthRisks.GetByReadableId(report.HealthRiskId);

            var eventSourceId = EventSourceId.New();

            Apply(eventSourceId, new AnonymousCaseReportRecieved
            {
                Id = eventSourceId,
                PhoneNumber = message.OriginNumber,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 = report.FemalesUnder5,
                NumberOfFemalesOver5 = report.FemalesOver5,
                NumberOfMalesUnder5 = report.MalesUnder5,
                NumberOfMalesOver5 = report.MalesOver5,
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Timestamp = message.Sent
            });
        }

        private void EmitCaseReportReceived(SingleCaseReportContent singleCaseReport, DataCollector dataCollector, TextMessage message)
        {
            var healthRisk = _healthRisks.GetByReadableId(singleCaseReport.HealthRiskId);

            var eventSourceId = EventSourceId.New();

            Apply(eventSourceId, new CaseReportReceived
            {
                Id = eventSourceId,
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
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Timestamp = message.Sent
            });
        }

        private void EmitAnonymousCaseReportReceived(SingleCaseReportContent singleCaseReport, TextMessage message)
        {
            var healthRisk = _healthRisks.GetByReadableId(singleCaseReport.HealthRiskId);
            var eventSourceId = EventSourceId.New();
            
            Apply(eventSourceId, new AnonymousCaseReportRecieved
            {
                Id = eventSourceId,
                PhoneNumber = message.OriginNumber,
                HealthRiskId = healthRisk.Id,
                NumberOfFemalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfFemalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Female ? 1 : 0,
                NumberOfMalesUnder5 =
                singleCaseReport.Age <= 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                NumberOfMalesOver5 =
                singleCaseReport.Age > 5 && singleCaseReport.Sex == Sex.Male ? 1 : 0,
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Timestamp = message.Sent
            });
        }

        private void EmitTextMessageParsingFailed(InvalidCaseReportContent invalidCaseReport, DataCollector dataCollector, TextMessage message)
        {
            var eventSourceId = EventSourceId.New();
            Apply(eventSourceId, new TextMessageParsingFailed
            {
                Id = eventSourceId,
                DataCollectorId = dataCollector.Id,
                Message = message.Message,
                ParsingErrorMessage = invalidCaseReport.ErrorMessage
            });
        }


        private void Apply(EventSourceId eventSourceId, IEvent @event)
        {

        }
        
    }
}