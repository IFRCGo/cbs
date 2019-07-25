/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Overview.LastWeekTotals
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportTotals> _caseReportTotalsRepository;

        public EventProcessor(IReadModelRepositoryFor<CaseReportTotals> caseReportTotalsRepository)
        {
            _caseReportTotalsRepository = caseReportTotalsRepository;
        }

        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            var today = Day.From(@event.Timestamp);

            for (var day = today; day < today + 7; day++)
            {
                var totals = _caseReportTotalsRepository.GetById(day);
                if (totals != null)
                {
                    totals.FemalesUnder5 += @event.NumberOfFemalesUnder5;
                    totals.MalesUnder5 += @event.NumberOfMalesUnder5;
                    totals.FemalesOver5 += @event.NumberOfFemalesAged5AndOlder;
                    totals.MalesOver5 += @event.NumberOfMalesAged5AndOlder;

                    _caseReportTotalsRepository.Update(totals);
                }
                else
                {
                    totals = new CaseReportTotals()
                    {
                        Id = day,
                        FemalesUnder5 = @event.NumberOfFemalesUnder5,
                        MalesUnder5 = @event.NumberOfMalesUnder5,
                        FemalesOver5 = @event.NumberOfFemalesAged5AndOlder,
                        MalesOver5 = @event.NumberOfMalesAged5AndOlder
                    };

                    _caseReportTotalsRepository.Insert(totals);
                }
            }
        }
    }
}
