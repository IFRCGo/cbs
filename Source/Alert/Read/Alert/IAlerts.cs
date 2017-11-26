using System;

namespace Read.Alert
{
    public interface IAlerts
    {
        Alert GetById(Guid id);
        Alert Get(Guid caseReportHealthRiskId, string caseReportLocation);
        void Save(Alert alert);
    }
}