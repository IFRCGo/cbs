using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.CaseReports;
using Concepts.HealthRisk;
using System;
using Concepts;
using System.Collections.Generic;

namespace Read.Map
{
    public class MapProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsBeforeDay> _caseReportRepository;
        readonly IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> _healthRisks;

        public MapProcessor(IReadModelRepositoryFor<CaseReportsBeforeDay> caseReportRepository,
                            IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> healthRisk){
            _caseReportRepository = caseReportRepository;
            _healthRisks = healthRisk;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){

            // Each day contains a health risk dictionary
            // Each healthrisk in the healthrisk dictionary contains two collections of case-reports from 7 and 30 days 
            var today                 = Day.Today;
            var totalCases            = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var locationForCaseReport = new Location(@event.Latitude, @event.Longitude);
            var healthRiskId          = @event.HealthRiskId;
            var healthRiskName        = _healthRisks.GetById(healthRiskId).Name; 

            var dayOfCaseReport = Day.From(@event.Timestamp);
            var timeLimit30Days = dayOfCaseReport + 30;  
            var timeLimit7Days  = dayOfCaseReport + 7;

            // Insert or update casereport depending on if it is in the list of not             
            for(Day i = dayOfCaseReport; i < timeLimit30Days; i++){
                var casesBeforeDay = _caseReportRepository.GetById(i);
                
                var caseReportForMap     = new CaseReportForMap(){
                    NumberOfPeople = totalCases,
                    Location = locationForCaseReport
                };

                var caseReportsLast7Days = new List<CaseReportForMap>{};
                if(i < timeLimit7Days){
                    caseReportsLast7Days.Add(caseReportForMap);
                }
                
                var caseReportsLast30Days = new List<CaseReportForMap>{ caseReportForMap };
                
                updateCasesBeforeDay(casesBeforeDay, caseReportForMap, caseReportsLast7Days, caseReportsLast30Days, healthRiskId, i, dayOfCaseReport, healthRiskName);
            }

        }
        void updateCasesBeforeDay(CaseReportsBeforeDay casesBeforeDay, 
                                                 CaseReportForMap caseReportMap,
                                                 List<CaseReportForMap> caseReportsLast7Days, 
                                                 List<CaseReportForMap> caseReportsLast30Days,
                                                 HealthRiskId healthRiskId, 
                                                 Day day,
                                                 Day dayOfCaseReport,
                                                 HealthRiskName healthRiskName)
        {
            if(casesBeforeDay == null){
                casesBeforeDay = new CaseReportsBeforeDay () {
                    Id = day,
                    CaseReportsPerHealthRisk = new Dictionary<HealthRiskId, CaseReportsRetrieved>()
                };
                casesBeforeDay.CaseReportsPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){
                                                                        HealthRiskName        = healthRiskName,
                                                                        CaseReportsLast7Days  = caseReportsLast7Days,
                                                                        CaseReportsLast30Days = caseReportsLast30Days
                };
                _caseReportRepository.Insert(casesBeforeDay);
            }
            else{
                if(casesBeforeDay.CaseReportsPerHealthRisk.ContainsKey(healthRiskId)){
                    casesBeforeDay.CaseReportsPerHealthRisk[healthRiskId].CaseReportsLast30Days.Add(caseReportMap);

                    // Check if the case report is within a week
                    if(day < dayOfCaseReport + 7){
                        casesBeforeDay.CaseReportsPerHealthRisk[healthRiskId].CaseReportsLast7Days.Add(caseReportMap);
                    }
                }else{
                    casesBeforeDay.CaseReportsPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){  
                                                                            HealthRiskName        = healthRiskName,
                                                                            CaseReportsLast7Days  = caseReportsLast7Days,
                                                                            CaseReportsLast30Days = caseReportsLast30Days
                    };
                }
                _caseReportRepository.Update(casesBeforeDay);
            }
        }
    }
}
