/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.Domain;
using Domain.Reports;
using Events.Reporting.CaseReports;
using Dolittle.Runtime.Commands.Coordination;
using System;
using System.Collections.Generic;

namespace Policies.CaseReports
{
    /// <summary>
    /// Class for processing external event <see cref="CaseReportReceived"/>
    /// </summary>
    public class CaseReportsProcessor : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<CaseReport> _caseReportAggregateRootRepository;
        private readonly ICommandContextManager _commandContextManager;
        public CaseReportsProcessor(

            ICommandContextManager commandContextManager,
            IAggregateRootRepositoryFor<CaseReport> caseReportAggregateRootRepository
            )
        {
            _commandContextManager = commandContextManager;
            _caseReportAggregateRootRepository = caseReportAggregateRootRepository;
        }

        [EventProcessor("780c53e3-6989-4f47-a523-b55eb31957cd")]
        public void Process(CaseReportReceived @event)
        {
             var transaction = _commandContextManager.EstablishForCommand(
                new Dolittle.Runtime.Commands.CommandRequest(
                    Guid.NewGuid(), 
                    Guid.NewGuid(), 
                    1, 
                    new Dictionary<string, object>()));
            var root = _caseReportAggregateRootRepository.Get(@event.CaseReportId);
            var data = new CaseReportData
            {
                CaseReportId = @event.CaseReportId,
                DataCollectorId = @event.DataCollectorId,
                HealthRiskId = @event.HealthRiskId,
                Latitude = @event.Latitude,
                Longitude = @event.Longitude,
                Timestamp = @event.Timestamp,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                Message = @event.Message,
                PhoneNumber = @event.Origin
            };

            root.ProcessReport(data);
            transaction.Commit();
        }
    }
}
