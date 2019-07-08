using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Dolittle.ReadModels;
using Concepts;
using Concepts.HealthRisks;
using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
namespace Read.Overview.Map
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsBeforeDay> _caseReportRepository;

        public EventProcessor(IReadModelRepositoryFor<CaseReportsBeforeDay> caseReportRepository){
            _caseReportRepository = caseReportRepository;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){
            var today = Day.Today;
            var origin = @event.Origin;
            var totalCases = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var region  = @event.Region;
            var LocationForCaseReport = new Location(@event.Latitude, @event.Longitude);
            var healthRiskId = @event.HealthRiskId;

            var dayOfCaseReport = Day.Of(@event.Timestamp);
            var timeLimit7Days  = dayOfCaseReport + 7;
            var timeLimit30Days = dayOfCaseReport + 30;  


            Day i = 0;                
            
            // Add to casesBeforeDay 7 days forward
            for(i = dayOfCaseReport; i < timeLimit7Days; i++){
                var casesBeforeDay = _caseReportRepository.GetById(i);
                
                if(casesBeforeDay == null){
                    casesBeforeDay = new CaseReportsBeforeDay () {
                        Id = i,
                        CasesPerHealthRisk = new Dictionary<HealthRiskId, CaseReportsRetrieved>()
                    };
                    casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){
                        Id = Guid.NewGuid(),
                        CaseReportsLast7Days = 
                            new List<CaseReport>{ 
                                new CaseReport(){
                                CaseReportsId = Guid.NewGuid(),
                                NumberOfPeople = totalCases,
                                Location = LocationForCaseReport,
                                Region = region
                    }  },
                        CaseReportsLast30Days = 
                            new List<CaseReport>{
                                new CaseReport(){
                                CaseReportsId = Guid.NewGuid(),
                                NumberOfPeople = totalCases,
                                Location = LocationForCaseReport,
                                Region = region
                    }}
                    };

                    _caseReportRepository.Insert(casesBeforeDay);
                }
                else{
                    if(casesBeforeDay.CasesPerHealthRisk.ContainsKey(healthRiskId)){
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast7Days.Add(new CaseReport(){ CaseReportsId = Guid.NewGuid(), NumberOfPeople = totalCases, Location = LocationForCaseReport, Region = region });
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast30Days.Add(new CaseReport(){ CaseReportsId = Guid.NewGuid(), NumberOfPeople = totalCases, Location = LocationForCaseReport, Region = region });
                    }else{
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){  
                            Id = Guid.NewGuid(),
                            CaseReportsLast7Days = new List<CaseReport>{
                                new CaseReport(){
                                    CaseReportsId = Guid.NewGuid(),
                                    NumberOfPeople = totalCases,
                                    Location = LocationForCaseReport,
                                    Region = region
                                }
                            },
                            CaseReportsLast30Days = 
                                new List<CaseReport>{
                                new CaseReport(){
                                    CaseReportsId = Guid.NewGuid(),
                                    NumberOfPeople = totalCases,
                                    Location = LocationForCaseReport,
                                    Region = region
                                }
                            } 
                        };
                    }
                    _caseReportRepository.Update(casesBeforeDay);
                }
            }
            Day tmp = dayOfCaseReport + 7;
            // Add to the remaining 23 days
            for(var y = tmp; y < timeLimit30Days; y++){
                var casesBeforeDay = _caseReportRepository.GetById(y);
                
                if(casesBeforeDay == null){
                    casesBeforeDay = new CaseReportsBeforeDay () {
                        Id = y,
                        CasesPerHealthRisk = new Dictionary<HealthRiskId, CaseReportsRetrieved>()
                    };
                    casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){
                        Id = Guid.NewGuid(),
                        CaseReportsLast7Days = new List<CaseReport>(){},
                        CaseReportsLast30Days = 
                            new List<CaseReport>{
                                new CaseReport(){
                                CaseReportsId = Guid.NewGuid(),
                                NumberOfPeople = totalCases,
                                Location = LocationForCaseReport,
                                Region = region
                    }}
                    };

                    _caseReportRepository.Insert(casesBeforeDay);
                }
                else{
                    if(casesBeforeDay.CasesPerHealthRisk.ContainsKey(healthRiskId)){
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast30Days.Add(new CaseReport(){ CaseReportsId = Guid.NewGuid(), NumberOfPeople = totalCases, Location = LocationForCaseReport, Region = region });
                    }else{
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){  
                            Id = Guid.NewGuid(),
                            CaseReportsLast7Days = new List<CaseReport>{},
                            CaseReportsLast30Days = 
                                new List<CaseReport>{
                                new CaseReport(){
                                    CaseReportsId = Guid.NewGuid(),
                                    NumberOfPeople = totalCases,
                                    Location = LocationForCaseReport,
                                    Region = region
                                }
                            } 
                        };
                    }
                    _caseReportRepository.Update(casesBeforeDay);
                }
            }
        }
        
    }
}

                    
