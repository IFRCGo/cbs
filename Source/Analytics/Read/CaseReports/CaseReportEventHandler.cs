using Read.HealthRisks;
using System.Linq;

namespace Read.CaseReports
{
    public class CaseReportsEventHandler : ICaseReportsEventHandler
    {
        private readonly MongoDBHandler _dbHandler;

        public CaseReportsEventHandler(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public void Handle(CaseReport caseReport)
        {
            _dbHandler.Insert(caseReport);

            var healthRisks = _dbHandler.GetQueryable<HealthRisk>();
            var healthRisk = healthRisks.First(h => h.HealthRiskId == caseReport.HealthRisk);

            healthRisk.ReportReceived(caseReport.Timestamp);
            _dbHandler.Update(healthRisk);
        }
    }
}