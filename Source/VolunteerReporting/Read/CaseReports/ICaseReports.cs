using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.CaseReports
{
    public interface ICaseReports : IGenericReadModelRepositoryFor<CaseReport, Guid>
    {
        IEnumerable<CaseReport> GetAll();
        Task<IEnumerable<CaseReport>> GetAllAsync();
    }
}
