using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.CaseReports;
using Concepts.HealthRisks;
using Concepts;
using System.Collections.Generic;
using Read.HealthRisks;

namespace Read.Map
{
    public class MapProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsLast7Days> _caseReportRepositoryLast7Days;
        readonly IReadModelRepositoryFor<CaseReportsLast4Weeks> _caseReportRepositoryLast4Weeks;
        readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public MapProcessor(IReadModelRepositoryFor<CaseReportsLast7Days> caseReportRepositoryLast7Days,
                            IReadModelRepositoryFor<CaseReportsLast4Weeks> caseReportRepositoryLast4Weeks,
                            IReadModelRepositoryFor<HealthRisk> healthRisk){
            _caseReportRepositoryLast7Days  = caseReportRepositoryLast7Days;
            _caseReportRepositoryLast4Weeks = caseReportRepositoryLast4Weeks;
            _healthRisks = healthRisk;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){

            // Each day contains a health risk dictionary
            // Each healthrisk in the healthrisk dictionary contains two collections of case-reports from 7 and 30 days 
            var totalCases            = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var locationForCaseReport = new Location(@event.Latitude, @event.Longitude);
            var healthRisk            = _healthRisks.GetById(@event.HealthRiskId); 

            var dayOfCaseReport = Day.From(@event.Timestamp);
            var timeLimit4Weeks = dayOfCaseReport + 28;  
            var timeLimit7Days  = dayOfCaseReport + 7;

            // Insert or update casereport depending on if it is in the list of not             
            for(Day day = dayOfCaseReport; day < timeLimit4Weeks; day++){
                var caseReport = new CaseReportForMap(){
                    HealthRiskName = healthRisk.Name,
                    NumberOfPeople = totalCases,
                    Location = locationForCaseReport
                };

                if(day < timeLimit7Days)
                {
                    UpdateCaseReportLast7Days(caseReport, day, healthRisk.HealthRiskNumber);
                }
                UpdateCaseReportLast4Weeks(caseReport, day, healthRisk.HealthRiskNumber);                
            }
        }

        private void UpdateCaseReportLast7Days(CaseReportForMap caseReportMap, Day day, HealthRiskNumber healthRiskNumber){
            var caseReportsLast7Days  = _caseReportRepositoryLast7Days.GetById(day);
            
            if(caseReportsLast7Days == null) 
            {
                caseReportsLast7Days = new CaseReportsLast7Days () {
                    Id = day,
                    CaseReportsPerHealthRisk = new Dictionary<HealthRiskNumber, IList<CaseReportForMap>> {}
                };
                caseReportsLast7Days.CaseReportsPerHealthRisk[healthRiskNumber] = new List<CaseReportForMap>{caseReportMap};
                _caseReportRepositoryLast7Days.Insert(caseReportsLast7Days);
            } else 
            {
                UpdateCaseReportsPerHealthRisk(caseReportsLast7Days.CaseReportsPerHealthRisk, caseReportMap, healthRiskNumber);
                _caseReportRepositoryLast7Days.Update(caseReportsLast7Days);  
            }
        }

        private void UpdateCaseReportLast4Weeks(CaseReportForMap caseReportMap, Day day, HealthRiskNumber healthRiskNumber){
            var caseReportsLast4Weeks = _caseReportRepositoryLast4Weeks.GetById(day);
            
            if(caseReportsLast4Weeks == null)
            {
                caseReportsLast4Weeks = new CaseReportsLast4Weeks () {
                    Id = day,
                    CaseReportsPerHealthRisk = new Dictionary<HealthRiskNumber, IList<CaseReportForMap>> {}
                };
                caseReportsLast4Weeks.CaseReportsPerHealthRisk[healthRiskNumber] = new List<CaseReportForMap>{caseReportMap};
                _caseReportRepositoryLast4Weeks.Insert(caseReportsLast4Weeks);
            } else 
            {
                UpdateCaseReportsPerHealthRisk(caseReportsLast4Weeks.CaseReportsPerHealthRisk, caseReportMap, healthRiskNumber);
                _caseReportRepositoryLast4Weeks.Update(caseReportsLast4Weeks);  
            }
        }
        
        private void UpdateCaseReportsPerHealthRisk(IDictionary<HealthRiskNumber, IList<CaseReportForMap>> caseReportsPerHealthRisk, CaseReportForMap caseReportForMap, HealthRiskNumber healthRiskNumber){
            if(caseReportsPerHealthRisk.ContainsKey(healthRiskNumber))
            {
                caseReportsPerHealthRisk[healthRiskNumber].Add(caseReportForMap);
            } else 
            {
                caseReportsPerHealthRisk[healthRiskNumber] = new List<CaseReportForMap>{caseReportForMap};
            }
        }
    }
}
