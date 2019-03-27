using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Read;

namespace Web.TestData
{
    public class TestDataService
    {
        private readonly MongoDBHandler _dbHandler;

        public TestDataService(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public string GetDataOwner(Guid dataOwnerId)
        {
            // Fetch the data owner from db
            var dbDataOwnerEntry = _dbHandler.GetDataOwnerQueryable().Where(x => x.DataOwnerId.Equals(dataOwnerId)).ToList();

            foreach (var dataOwner in dbDataOwnerEntry)
            {

                // Create the DataCollectorReport
                var dataCollectorReports = new List<DataCollectorReport>();
                foreach (var dataCollector in dataOwner.DataCollectors)
                {
                    
                    var dbCaseEntries = _dbHandler.GetQueryable().Where(x => x.DataCollectorId.Equals(dataCollector)).ToList();
                    var dataCollectorReport = new DataCollectorReport()
                    {
                        DataCollectorId = dataCollector,
                        HealthRiskAggregatedReports = new List<HealthRiskAggregatedReport>()
                    };

                    foreach (var entry in dbCaseEntries)
                    {
                        dataCollectorReport.Longitude = entry.Longitude;
                        dataCollectorReport.Latitude = entry.Latitude;
                        
                        HealthRiskAggregatedReport report = dataCollectorReport.HealthRiskAggregatedReports.Find(x => x.HealthRiskId.Equals(entry.HealthRisk));
                        if (report != null)
                        {
                            // Aggregate numbers
                            report.NumberOfFemalesUnder5 += entry.NumberOfFemalesUnder5;
                            report.NumberOfMalesUnder5 += entry.NumberOfMalesUnder5;
                            report.NumberOfFemalesAged5AndOlder += entry.NumberOfFemalesAged5AndOlder;
                            report.NumberOfMalesAged5AndOlder += entry.NumberOfMalesAged5AndOlder;
                        }
                        else
                        {
                            // Add a new health risk
                            dataCollectorReport.HealthRiskAggregatedReports.Add(new HealthRiskAggregatedReport()
                            {
                                HealthRiskId = entry.HealthRisk,
                                NumberOfMalesUnder5 = entry.NumberOfMalesUnder5,
                                NumberOfFemalesUnder5 = entry.NumberOfFemalesUnder5,
                                NumberOfMalesAged5AndOlder = entry.NumberOfMalesAged5AndOlder,
                                NumberOfFemalesAged5AndOlder = entry.NumberOfFemalesAged5AndOlder
                            });
                        }
                    }

                    dataCollectorReports.Add(dataCollectorReport);
                }

                // Create the DataOwnerReport
                var dataOwnerReport = new DataOwnerReport()
                {
                    DataOwnerId = dataOwner.DataOwnerId,
                    Longitude = dataOwner.Longitude,
                    Latitude = dataOwner.Latitude,
                    DataCollectorReports = dataCollectorReports
                };

                return JsonConvert.SerializeObject(dataOwnerReport);
            }

            return null;
        }
    }
}
