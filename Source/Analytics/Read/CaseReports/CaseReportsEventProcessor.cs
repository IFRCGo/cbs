using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Read.CaseReports;
using Dolittle.ReadModels;
using Dolittle.Logging;
using Concepts;
using Read.HealthRisk;


namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> _caseReportRepository;
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _caseReportsPerRegionRepository;

        readonly IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> _healthRisks;

        public CaseReportsEventProcessor(
            IReadModelRepositoryFor<CaseReport> caseReportRepository, 
            IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repository, 
            IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> healthRisks
            )
        {
            _caseReportRepository = caseReportRepository;
            _caseReportsPerRegionRepository = repository;
            _healthRisks = healthRisks;
        }

       [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            // Insert CaseReports
            var caseReport = new CaseReport(@event.DataCollectorId, 
            @event.HealthRiskId, @event.Origin, @event.Message, @event.NumberOfMalesUnder5, @event.NumberOfMalesAged5AndOlder, 
            @event.NumberOfFemalesUnder5, @event.NumberOfFemalesAged5AndOlder, @event.Longitude, @event.Latitude,
            @event.Timestamp, @event.Region);
            
            _caseReportRepository.Insert(caseReport);

            var healthRisk = _healthRisks.GetById(@event.HealthRiskId);

            // Insert regionwise
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