using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.CaseReports;
using Concepts.HealthRisk;
using System;
using Concepts;
using System.Collections.Generic;
using System.Collections;

namespace Read.Map
{
    public class MapProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<CaseReportsBeforeDay> _caseReportRepository;

        public MapProcessor(IReadModelRepositoryFor<CaseReportsBeforeDay> caseReportRepository){
            _caseReportRepository = caseReportRepository;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){
            // Each day contains a health risk dictionary
            // Each health risk in the health risk dictionary contains two collections of casereports from 7 and 30 days 

            var today = Day.Today;
            var origin = @event.Origin;
            var totalCases = @event.NumberOfFemalesAged5AndOlder + @event.NumberOfFemalesUnder5 + @event.NumberOfMalesAged5AndOlder + @event.NumberOfMalesUnder5;
            var LocationForCaseReport = new Location(@event.Latitude, @event.Longitude);
            var healthRiskId = @event.HealthRiskId;

            var dayOfCaseReport = Day.From(@event.Timestamp);
            var timeLimit7Days  = dayOfCaseReport + 7;
            var timeLimit30Days = dayOfCaseReport + 30;  

            // Insert or update casereport depending on if it is in the list of not
            Day i = 0;                
            for(i = dayOfCaseReport; i < timeLimit7Days; i++){
                var casesBeforeDay = _caseReportRepository.GetById(i);
                
                if(casesBeforeDay == null){
                    casesBeforeDay = new CaseReportsBeforeDay () {
                        Id = i,
                        CasesPerHealthRisk = new Dictionary<HealthRiskId, CaseReportsRetrieved>()
                    };
                    casesBeforeDay.CasesPerHealthRisk[healthRiskId] =   new CaseReportsRetrieved(){
                                                                            Id = Guid.NewGuid(),
                                                                            CaseReportsLast7Days  = new List<CaseReportForMap>{ 
                                                                                                        new CaseReportForMap(){
                                                                                                            CaseReportsId = Guid.NewGuid(),
                                                                                                            NumberOfPeople = totalCases,
                                                                                                            Location = LocationForCaseReport 
                                                                                                        }  
                                                                                                    },
                                                                            CaseReportsLast30Days = new List<CaseReportForMap>{
                                                                                                        new CaseReportForMap(){
                                                                                                            CaseReportsId = Guid.NewGuid(),
                                                                                                            NumberOfPeople = totalCases,
                                                                                                            Location = LocationForCaseReport
                                                                                                        }
                                                                                                    }
                    };
                    _caseReportRepository.Insert(casesBeforeDay);
                }
                else{
                    if(casesBeforeDay.CasesPerHealthRisk.ContainsKey(healthRiskId)){
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast7Days.Add(
                                                                                            new CaseReportForMap(){ 
                                                                                                CaseReportsId = Guid.NewGuid(),
                                                                                                 NumberOfPeople = totalCases, 
                                                                                                 Location = LocationForCaseReport 
                                                                                            });
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast30Days.Add(
                                                                                            new CaseReportForMap(){ 
                                                                                                CaseReportsId = Guid.NewGuid(), 
                                                                                                NumberOfPeople = totalCases, 
                                                                                                Location = LocationForCaseReport
                                                                                            });
                    }else{
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId]  =  new CaseReportsRetrieved(){  
                                                                                Id = Guid.NewGuid(),
                                                                                CaseReportsLast7Days = new List<CaseReportForMap>{
                                                                                    new CaseReportForMap(){
                                                                                        CaseReportsId = Guid.NewGuid(),
                                                                                        NumberOfPeople = totalCases,
                                                                                        Location = LocationForCaseReport
                                                                                    }
                                                                                },
                                                                                CaseReportsLast30Days = 
                                                                                    new List<CaseReportForMap>{
                                                                                    new CaseReportForMap(){
                                                                                        CaseReportsId = Guid.NewGuid(),
                                                                                        NumberOfPeople = totalCases,
                                                                                        Location = LocationForCaseReport
                                                                                    }
                                                                                } 
                        };
                    }
                    _caseReportRepository.Update(casesBeforeDay);
                }
            }

            // Add to the remaining 23 days to the casereports 30 days back in time
            Day after7Days = dayOfCaseReport + 7;
            for(var y = after7Days; y < timeLimit30Days; y++){
                var casesBeforeDay = _caseReportRepository.GetById(y);
                
                if(casesBeforeDay == null){
                    casesBeforeDay = new CaseReportsBeforeDay () {
                        Id = y,
                        CasesPerHealthRisk = new Dictionary<HealthRiskId, CaseReportsRetrieved>()
                    };
                    casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){
                        Id = Guid.NewGuid(),
                        CaseReportsLast7Days = new List<CaseReportForMap>(){},
                        CaseReportsLast30Days = new List<CaseReportForMap>{ 
                                                    new CaseReportForMap(){
                                                            CaseReportsId = Guid.NewGuid(),
                                                            NumberOfPeople = totalCases,
                                                            Location = LocationForCaseReport
                                                    }
                                                }
                    };

                    _caseReportRepository.Insert(casesBeforeDay);
                }
                else{
                    if(casesBeforeDay.CasesPerHealthRisk.ContainsKey(healthRiskId)){
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId].CaseReportsLast30Days.Add(
                                                                                        new CaseReportForMap(){ 
                                                                                            CaseReportsId = Guid.NewGuid(), 
                                                                                            NumberOfPeople = totalCases, 
                                                                                            Location = LocationForCaseReport 
                                                                                        });
                    }else{
                        casesBeforeDay.CasesPerHealthRisk[healthRiskId] = new CaseReportsRetrieved(){  
                                                                                Id = Guid.NewGuid(),
                                                                                CaseReportsLast7Days  = new List<CaseReportForMap>{},
                                                                                CaseReportsLast30Days = new List<CaseReportForMap>{
                                                                                        new CaseReportForMap(){
                                                                                            CaseReportsId = Guid.NewGuid(),
                                                                                            NumberOfPeople = totalCases,
                                                                                            Location = LocationForCaseReport
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
