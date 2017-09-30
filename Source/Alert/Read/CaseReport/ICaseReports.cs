using System;
using System.Collections.Generic;

namespace Read
{
    public interface ICaseReports
    {
        CaseReport GetById(Guid id);
        IEnumerable<CaseReport> GetCaseReportsAfterDate(DateTime date);
        void Save(CaseReport caseReport);
    }
}
