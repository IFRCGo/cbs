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

        [EventProcessor("c09b9902-8240-ae58-36ba-84e954b674e3")]
        public void Process(CaseReportReceived @event)
        {
            var today = Day.From(@event.Timestamp);

            for (var day = today; day < today + 7; day++)
            {
                var totals = _caseReportTotalsRepository.GetById(day);
                if (totals != null)
                {
                    totals.Female += @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5;
                    totals.Male += @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
                    totals.Over5 += @event.NumberOfMalesAged5AndOlder + @event.NumberOfFemalesAged5AndOlder;
                    totals.Under5 += @event.NumberOfMalesUnder5 + @event.NumberOfFemalesUnder5;

                    _caseReportTotalsRepository.Update(totals);
                }
                else
                {
                    totals = new CaseReportTotals()
                    {
                        Id = day,
                        Female = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5,
                        Male = @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5,
                        Under5 = @event.NumberOfMalesUnder5 + @event.NumberOfFemalesUnder5,
                        Over5 = @event.NumberOfMalesAged5AndOlder + @event.NumberOfFemalesAged5AndOlder
                    };

                    _caseReportTotalsRepository.Insert(totals);
                }
            }
        }
    }
}
