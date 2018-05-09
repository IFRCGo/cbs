using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.CaseReports
{
    public interface ICaseReports : IExtendedReadModelRepositoryFor<CaseReport>
    {
        IEnumerable<CaseReport> GetAll();
        Task<IEnumerable<CaseReport>> GetAllAsync();
    }
}
