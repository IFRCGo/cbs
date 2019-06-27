using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Read.CaseReports;
using Dolittle.ReadModels;
using Dolittle.Logging;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> _caseReportRepository;
        private readonly IReadModelRepositoryFor<CaseReportTotals> _caseReportTotalsRepository;


        public CaseReportsEventProcessor(
            IReadModelRepositoryFor<CaseReport> caseReportRepository,
            IReadModelRepositoryFor<CaseReportTotals> caseReportTotalsRepository)
        {
            _caseReportRepository = caseReportRepository;
            _caseReportTotalsRepository = caseReportTotalsRepository;
        }


        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport()
            {
                Male = @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5,
                Female = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5,
                Over5 = @event.NumberOfMalesAged5AndOlder + @event.NumberOfFemalesAged5AndOlder,
                Under5 = @event.NumberOfMalesUnder5 + @event.NumberOfFemalesUnder5,
                HealthRiskId = @event.HealthRiskId,
                Received = @event.Timestamp,
            };

            _caseReportRepository.Insert(caseReport);
            InsertTotalsForComingWeek(@event);
        }

        public void InsertTotalsForComingWeek(CaseReportReceived caseReport)
        {
            // insert/update totals for the coming week
            var today = Day.For(caseReport.Timestamp);

            for (var day = today; day <= today + 7; day++)
            {
                var totals = _caseReportTotalsRepository.GetById(day);
                if (totals != null)
                {
                    totals.Female += caseReport.NumberOfFemalesAged5AndOlder + caseReport.NumberOfFemalesUnder5;
                    totals.Male += caseReport.NumberOfMalesAged5AndOlder + caseReport.NumberOfMalesUnder5;
                    totals.Over5 += caseReport.NumberOfMalesAged5AndOlder + caseReport.NumberOfFemalesAged5AndOlder;
                    totals.Under5 += caseReport.NumberOfMalesUnder5 + caseReport.NumberOfFemalesUnder5;
                }
                else
                {
                    totals = new CaseReportTotals()
                    {
                        Id = day,
                        Female = caseReport.NumberOfFemalesAged5AndOlder + caseReport.NumberOfFemalesUnder5,
                        Male = caseReport.NumberOfMalesAged5AndOlder + caseReport.NumberOfMalesUnder5,
                        Under5 = caseReport.NumberOfMalesUnder5 + caseReport.NumberOfFemalesUnder5,
                        Over5 = caseReport.NumberOfMalesAged5AndOlder + caseReport.NumberOfFemalesAged5AndOlder
                    };
                }

                _caseReportTotalsRepository.Insert(totals);
            }
        }
    }
}