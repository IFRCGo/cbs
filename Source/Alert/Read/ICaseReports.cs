using System;

namespace Read
{
    public interface ICaseReports
    {
        CaseReport GetById(Guid id);
        void Save(CaseReport caseReport);
    }
}
