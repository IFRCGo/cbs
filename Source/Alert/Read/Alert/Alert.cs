using System;
using System.Collections.Generic;

namespace Read.Alert
{
    public class Alert : Entity
    {
        List<CaseReport> _caseReports;

        public Alert()
        {
            _caseReports = new List<CaseReport>();
        }

        public List<CaseReport> CaseReports
        {
            get => _caseReports;
            set => _caseReports = new List<CaseReport>(value);
        }

        public Guid HealthRiskId { get; set; }
        public string Location { get; set; }
    }
}