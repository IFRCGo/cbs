using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Dolittle.ReadModels;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReportsPerRegionLast7DaysProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _caseReportsPerRegionRepository;

        public CaseReportsPerRegionLast7DaysProcessor(IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repository)
        {
            _caseReportsPerRegionRepository = repository;
        }

        public void Process(CaseReportReceived @event)
        {
            var today = Day.Of(@event.Timestamp);

            for (var day = today; day < today + 7; day++)
            {
                var reportsPerRegion = _caseReportsPerRegionRepository.GetById(day);
                if (reportsPerRegion != null)
                {
                    for (var i=0; i<reportsPerRegion.CaseReportsPerRegion.Count; i++)
                    {
                        var region = reportsPerRegion.CaseReportsPerRegion[i];
                        if (region.Region == @event.Region) {
                            region.NumberOfCaseReports 
                                +=@event.NumberOfMalesUnder5
                                +@event.NumberOfMalesAged5AndOlder
                                +@event.NumberOfFemalesUnder5
                                +@event.NumberOfFemalesAged5AndOlder;
                        }
                    }
                    _caseReportsPerRegionRepository.Update(reportsPerRegion);
                }
                else 
                {
                    reportsPerRegion = new CaseReportsPerRegionLast7Days()
                    {
                        Id = day,
                        CaseReportsPerRegion = new [] {
                            new CaseReportsInRegionLast7Days(){
                                Id = day,
                                Region = @event.Region,
                                NumberOfCaseReports = 
                                    @event.NumberOfMalesUnder5
                                    +@event.NumberOfMalesAged5AndOlder
                                    +@event.NumberOfFemalesUnder5
                                    +@event.NumberOfFemalesAged5AndOlder
                            }
                        }
                    };

                    _caseReportsPerRegionRepository.Insert(reportsPerRegion);
                }
            }
        }

    }
}
