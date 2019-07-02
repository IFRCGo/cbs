using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Read.CaseReports;
using Dolittle.ReadModels;
using Dolittle.Logging;
using Concepts;
using Read.HealthRisk;
using System.Collections.Generic;
using System;


namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> _caseReportRepository;
        readonly IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> _caseReportsPerRegionLast7DaysRepository;
        readonly IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> _healthRisks;

        public CaseReportsEventProcessor(
            IReadModelRepositoryFor<CaseReport> caseReportRepository, 
            IReadModelRepositoryFor<CaseReportsPerRegionLast7Days> repository, 
            IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> healthRisks
            )
        {
            _caseReportRepository = caseReportRepository;
            _caseReportsPerRegionLast7DaysRepository = repository;
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

            var healthRisk = _healthRisks.GetById(caseReport.HealthRiskId);
            if(healthRisk == null) 
            {
                healthRisk.HealthRiskName = "Unknown health risk";
            };

            // Insert by health risk and region
            var today = Day.Of(@event.Timestamp);
            var totalCases = caseReport.NumberOfMalesUnder5
                                +caseReport.NumberOfMalesAged5AndOlder
                                +caseReport.NumberOfFemalesUnder5
                                +caseReport.NumberOfFemalesAged5AndOlder;
            Region region = caseReport.Region;

            for (var day = today; day < today + 7; day++)
            {
                var dayReport = _caseReportsPerRegionLast7DaysRepository.GetById(day);
                if (dayReport != null)
                {
                    for (var i=0; i<dayReport.HealthRisks.Count; i++)
                    {
                        var healthRiskByRegions = dayReport.HealthRisks[i];
                        if (healthRiskByRegions.Id == caseReport.HealthRiskId)
                        {
                            for (var j=0; j<healthRiskByRegions.Regions.Count; j++)
                            {
                                var regionsWithHealthRisk = healthRiskByRegions.Regions[j];
                                if (regionsWithHealthRisk.Id == region)
                                {
                                    regionsWithHealthRisk.NumCases += totalCases;
                                }
                            }
                        }
                    }
                    
                    _caseReportsPerRegionLast7DaysRepository.Update(dayReport);
                }
                else 
                {
                    var RegionWithHealthRisk = new RegionWithHealthRisk() 
                                    {
                                        Id = region,
                                        NumCases = totalCases
                                    };

                    var HealthRisksInRegionsLast7Days = new HealthRisksInRegionsLast7Days()
                            {
                                Id = caseReport.HealthRiskId,
                                HealthRiskName = healthRisk.HealthRiskName,
                                Regions = null
                            };

                    HealthRisksInRegionsLast7Days.Regions = new [] 
                                {
                                    RegionWithHealthRisk
                                };

                    dayReport = new CaseReportsPerRegionLast7Days()
                    {
                        Id = day,
                        HealthRisks = new [] 
                        {
                            HealthRisksInRegionsLast7Days
                        }
                    };
                    _caseReportsPerRegionLast7DaysRepository.Insert(dayReport);
                }
            };
        }
    }
}