using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReports
{
    public interface ICaseReports : IExtendedReadModelRepositoryFor<CaseReport>
    {
        IEnumerable<CaseReport> GetAll();
    }
}
