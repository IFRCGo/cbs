using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.CaseReports;
using Concepts.HealthRisk;
using Concepts;
using System.Collections.Generic;

namespace Read.Map
{
    public class MapProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsLast7Days> _caseReportRepositoryLast7Days;
        readonly IReadModelRepositoryFor<CaseReportsLast30Days> _caseReportRepositoryLast30Days;
        readonly IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> _healthRisks;

        public MapProcessor(IReadModelRepositoryFor<CaseReportsLast7Days> caseReportRepositoryLast7Days,
                            IReadModelRepositoryFor<CaseReportsLast30Days> caseReportRepositoryLast30Days,
                            IReadModelRepositoryFor<Read.HealthRisk.HealthRisk> healthRisk){
            _caseReportRepositoryLast7Days  = caseReportRepositoryLast7Days;
            _caseReportRepositoryLast30Days = caseReportRepositoryLast30Days;
            _healthRisks = healthRisk;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){

            // Each day contains a health risk dictionary
            // Each healthrisk in the healthrisk dictionary contains two collections of case-reports from 7 and 30 days 
            var totalCases            = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var locationForCaseReport = new Location(@event.Latitude, @event.Longitude);
            var healthRiskId          = @event.HealthRiskId;
            var healthRiskName        = _healthRisks.GetById(healthRiskId).Name; 

            var dayOfCaseReport = Day.From(@event.Timestamp);
            var timeLimit30Days = dayOfCaseReport + 30;  
            var timeLimit7Days  = dayOfCaseReport + 7;

            // Insert or update casereport depending on if it is in the list of not             
            for(Day day = dayOfCaseReport; day < timeLimit30Days; day++){
                var caseReport = new CaseReportForMap(){
                    NumberOfPeople = totalCases,
                    Location = locationForCaseReport
                };

                if(day < timeLimit7Days)
                {
                    UpdateCaseReportLast7Days(caseReport, day, healthRiskName);
                }
                UpdateCaseReportLast30Days(caseReport, day, healthRiskName);                
            }
        }

        private void UpdateCaseReportLast7Days(CaseReportForMap caseReportMap, Day day, HealthRiskName healthRiskName){
            var caseReportsLast7Days  = _caseReportRepositoryLast7Days.GetById(day);
            
            if(caseReportsLast7Days == null) 
            {
                caseReportsLast7Days = new CaseReportsLast7Days () {
                    Id = day,
                    CaseReportsPerHealthRisk = new Dictionary<HealthRiskName, IList<CaseReportForMap>> {}
                };
                caseReportsLast7Days.CaseReportsPerHealthRisk[healthRiskName] = new List<CaseReportForMap>{caseReportMap};
                _caseReportRepositoryLast7Days.Insert(caseReportsLast7Days);
            } else 
            {
                UpdateCaseReportsPerHealthRisk(caseReportsLast7Days.CaseReportsPerHealthRisk, caseReportMap, healthRiskName);
                _caseReportRepositoryLast7Days.Update(caseReportsLast7Days);  
            }
        }

        private void UpdateCaseReportLast30Days(CaseReportForMap caseReportMap, Day day, HealthRiskName healthRiskName){
            var caseReportsLast30Days = _caseReportRepositoryLast30Days.GetById(day);
            
            if(caseReportsLast30Days == null)
            {
                caseReportsLast30Days = new CaseReportsLast30Days () {
                    Id = day,
                    CaseReportsPerHealthRisk = new Dictionary<HealthRiskName, IList<CaseReportForMap>> {}
                };
                caseReportsLast30Days.CaseReportsPerHealthRisk[healthRiskName] = new List<CaseReportForMap>{caseReportMap};
                _caseReportRepositoryLast30Days.Insert(caseReportsLast30Days);
            } else 
            {
                UpdateCaseReportsPerHealthRisk(caseReportsLast30Days.CaseReportsPerHealthRisk, caseReportMap, healthRiskName);
                _caseReportRepositoryLast30Days.Update(caseReportsLast30Days);  
            }
        }
        
        private void UpdateCaseReportsPerHealthRisk(IDictionary<HealthRiskName, IList<CaseReportForMap>> caseReportsPerHealthRisk, CaseReportForMap caseReportForMap, HealthRiskName healthRiskName){
            if(caseReportsPerHealthRisk.ContainsKey(healthRiskName))
            {
                caseReportsPerHealthRisk[healthRiskName].Add(caseReportForMap);
            } else 
            {
                caseReportsPerHealthRisk[healthRiskName] = new List<CaseReportForMap>{caseReportForMap};
            }
        }
    }
}
