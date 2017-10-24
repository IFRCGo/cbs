using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReports
    {
        void Save(CaseReport caseReport);
        Task<IEnumerable<CaseReport>> GetAllAsync();
    }
}
