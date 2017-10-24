using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AnonymousCaseReports
{
    public interface IAnonymousCaseReports
    {
        void Save(AnonymousCaseReport anonymousCaseReport);
        Task<IEnumerable<AnonymousCaseReport>> GetAllAsync();
    }
}
