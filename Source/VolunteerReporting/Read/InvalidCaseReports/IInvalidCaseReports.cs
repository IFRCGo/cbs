using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReports
    {
        Task Save(InvalidCaseReport caseReport);
        Task<IEnumerable<InvalidCaseReport>> GetAllAsync();
    }
}
