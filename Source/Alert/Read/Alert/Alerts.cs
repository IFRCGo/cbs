using System;
using MongoDB.Driver;

namespace Read.Alert
{
    public class Alerts : Repository<Alert>, IAlerts
    {
        public Alerts(IMongoDatabase database) : base(database, "Alert")
        {
        }

        public Alert Get(Guid caseReportHealthRiskId, string caseReportLocation)
        {
            return _collection.Find(c => c.HealthRiskId == caseReportHealthRiskId && c.Location == caseReportLocation).SingleOrDefault();
        }
    }
}