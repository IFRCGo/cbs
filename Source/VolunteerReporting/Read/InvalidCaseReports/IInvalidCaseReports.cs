using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReports
    {
        void Save(InvalidCaseReport caseReport);
        Task<IEnumerable<InvalidCaseReport>> GetAllAsync();
    }
}
