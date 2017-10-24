/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Infrastructure.TextMessaging;
using Concepts;
using Domain;
using Read.DataCollectors;
using Read.HealthRisks;
using doLittle.Domain;
using System;

namespace TextMessaging
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanProcessTextMessage"/>
    /// </summary>
    public class TextMessageProcessor : ICanProcessTextMessage
    {
        readonly IDataCollectors _dataCollectors;
        readonly IHealthRisks _healthRisks;
        readonly ITextMessageParser _textMessageParser;
        private readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="TextMessageProcessor"/>
        /// </summary>
        /// <param name="dataCollectors"><see cref="IDataCollectors"/></param>
        /// <param name="healthRisks"><see cref="IHealthRisks"/></param>
        /// <param name="textMessageParser"><see cref="ITextMessageContentParser"/></param>
        /// <param name="caseReportingRepository"><see cref="IAggregateRootRepository<CaseReporting>"/></param>
        public TextMessageProcessor(
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks,
            ITextMessageParser textMessageParser,
            IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
        {
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
            _textMessageParser = textMessageParser;
            _caseReportingRepository = caseReportingRepository;
        }

        /// <inheritdoc/>
        public void Process(TextMessage message)
        {
            var parsingResult = _textMessageParser.Parse(message);
            var dataCollectorId = _dataCollectors.GetIdByPhoneNumber(message.OriginNumber);
            var unknown = dataCollectorId == DataCollectorId.NotSet;

            var caseReportId = Guid.NewGuid();
            var caseReporting = _caseReportingRepository.Get(caseReportId);
            if (!parsingResult.IsValid)
            {
                ReportInvalidMessage(message, parsingResult, dataCollectorId, unknown, caseReporting);
                return;
            }

            // Todo: Should we have a validation check if we actually get a health risk id
            var healthRiskId = _healthRisks.GetIdFromReadableId(parsingResult.Numbers[0]);
            if (!parsingResult.HasMultipleCases)
            {
                var sex = (Sex)parsingResult.Numbers[1];
                var age = parsingResult.Numbers[2];
                ReportSingle(message, dataCollectorId, caseReporting, healthRiskId, sex, age, unknown);
            }
            else
            {
                var malesUnder5 = parsingResult.Numbers[1];
                var malesOver5 = parsingResult.Numbers[2];
                var femalesUnder5 = parsingResult.Numbers[3];
                var femalesOver5 = parsingResult.Numbers[4];

                ReportMultiple(message, dataCollectorId, unknown, caseReporting, healthRiskId, malesUnder5, malesOver5, femalesUnder5, femalesOver5);
            }
        }

        void ReportInvalidMessage(TextMessage message, TextMessageParsingResult parsingResult, DataCollectorId dataCollectorId, bool unknown, CaseReporting caseReporting)
        {
            if (!unknown) caseReporting.ReportInvalidReport(dataCollectorId, message.Message, parsingResult.ErrorMessages);
            else caseReporting.ReportInvalidReportFromUnknownDataCollector(message.OriginNumber, message.Message, parsingResult.ErrorMessages);
        }

        void ReportSingle(
            TextMessage message,
            DataCollectorId dataCollectorId,
            CaseReporting caseReporting,
            Guid healthRiskId,
            Sex sex,
            int age,
            bool unknown)
        {
            if (!unknown)
            {
                caseReporting.Report(
                    dataCollectorId,
                    healthRiskId,
                    sex,
                    age,
                    message.Longitude,
                    message.Latitude);
            }
            else
            {
                caseReporting.ReportFromUnknownDataCollector(
                    message.OriginNumber,
                    healthRiskId,
                    sex,
                    age,
                    message.Longitude,
                    message.Latitude);

            }
        }


        void ReportMultiple(TextMessage message, DataCollectorId dataCollectorId, bool unknown, CaseReporting caseReporting, Guid healthRiskId, int malesUnder5, int malesOver5, int femalesUnder5, int femalesOver5)
        {
            if (!unknown)
            {
                caseReporting.ReportMultiple(
                    dataCollectorId,
                    healthRiskId,
                    malesUnder5,
                    malesOver5,
                    femalesUnder5,
                    femalesOver5,
                    message.Longitude,
                    message.Latitude
                );
            }
            else
            {
                caseReporting.ReportMultipleFromUnknownDataCollector(
                    message.OriginNumber,
                    healthRiskId,
                    malesUnder5,
                    malesOver5,
                    femalesUnder5,
                    femalesOver5,
                    message.Longitude,
                    message.Latitude
                );
            }
        }
    }
}