using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Dolittle.ReadModels;
using Concepts;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> _caseReportRepository;
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _caseReportsPerRegionLast7DaysRepository;
        readonly IReadModelRepositoryFor<Read.HealthRisks.HealthRisk> _healthRisks;
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;

        public CaseReportsEventProcessor(
            IReadModelRepositoryFor<CaseReport> caseReportRepository, 
            IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repository, 
            IReadModelRepositoryFor<Read.HealthRisks.HealthRisk> healthRisks,
            IReadModelRepositoryFor<DataCollector> dataCollectors
            )
        {
            _caseReportRepository = caseReportRepository;
            _caseReportsPerRegionLast7DaysRepository = repository;
            _healthRisks = healthRisks;
            _dataCollectors = dataCollectors;
        }

        public RegionWithHealthRisk addRegionWithCases(Region region, NumberOfPeople numCases)
        {
            return new RegionWithHealthRisk()
            {
                Id = region,
                NumCases = numCases
            };
        }

        
        
       [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            // Insert CaseReports
            var caseReport = new CaseReport(@event.DataCollectorId, 
            @event.HealthRiskId, @event.Origin, @event.Message, @event.NumberOfMalesUnder5, @event.NumberOfMalesAged5AndOlder, 
            @event.NumberOfFemalesUnder5, @event.NumberOfFemalesAged5AndOlder, @event.Longitude, @event.Latitude,
            @event.Timestamp);
            
            _caseReportRepository.Insert(caseReport);

            var healthRisk = _healthRisks.GetById(caseReport.HealthRiskId);
            var dataCollector = _dataCollectors.GetById(caseReport.DataCollectorId);

            // Insert by health risk and region
            var today = Day.Of(caseReport.Timestamp);
            var totalCases = caseReport.NumberOfMalesUnder5
                                +caseReport.NumberOfMalesAged5AndOlder
                                +caseReport.NumberOfFemalesUnder5
                                +caseReport.NumberOfFemalesAged5AndOlder;
            Region region = dataCollector.Region;

            for (var day = today; day < today + 7; day++)
            {
                var dayReport = _caseReportsPerRegionLast7DaysRepository.GetById(day);
                if (dayReport != null)
                {
                    var healthRiskExists = false;
                    for (var i=0; i<dayReport.HealthRisks.Count; i++)
                    {
                        
                        var healthRiskByRegions = dayReport.HealthRisks[i];
                        if (healthRiskByRegions.Id == caseReport.HealthRiskId)
                        {
                            healthRiskExists = true;

                            var foundRegion = false;
                            for (var j=0; j<healthRiskByRegions.Regions.Count; j++)
                            {
                                var regionsWithHealthRisk = healthRiskByRegions.Regions[j];
                                if (regionsWithHealthRisk.Id == region)
                                {
                                    foundRegion = true;
                                    regionsWithHealthRisk.NumCases += totalCases;
                                }
                            }
                            if (!foundRegion)
                            {
                                healthRiskByRegions.Regions.Add(addRegionWithCases(region, totalCases));
                            }
                        }
                    }
                    if(!healthRiskExists)
                    {
                        dayReport.HealthRisks.Add(new HealthRisksInRegionsLast7Days()
                        {
                            Id = caseReport.HealthRiskId,
                            HealthRiskName = healthRisk.Name,
                            Regions = new [] { addRegionWithCases(region, totalCases) }
                        });
                    }
                    
                    _caseReportsPerRegionLast7DaysRepository.Update(dayReport);
                }
                else 
                {
                    dayReport = new CaseReportsPerRegionLast7Days()
                    {
                        Id = day,
                        HealthRisks = new [] 
                        {
                            new HealthRisksInRegionsLast7Days()
                            {
                                Id = caseReport.HealthRiskId,
                                HealthRiskName = healthRisk.Name,
                                Regions = new []{ addRegionWithCases(region, totalCases) }
                            }
                        }
                    };
                    _caseReportsPerRegionLast7DaysRepository.Insert(dayReport);
                }
            };
        }        
    }
}