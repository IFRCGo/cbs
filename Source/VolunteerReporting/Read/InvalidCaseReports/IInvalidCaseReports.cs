using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReports
    {
        void Save(InvalidCaseReport caseReport);
        Task SaveAsync(InvalidCaseReport caseReport);
        IEnumerable<InvalidCaseReport> GetAll();
        Task<IEnumerable<InvalidCaseReport>> GetAllAsync();
    }
}
