using System;
using System.Collections.Generic;

namespace Read
{
    public interface ICaseReports
    {
        CaseReport GetById(Guid id);
        List<CaseReport> GetCaseReportsAfterDate(DateTime date, Guid diseaseId);
        void Save(CaseReport caseReport);
    }
}
