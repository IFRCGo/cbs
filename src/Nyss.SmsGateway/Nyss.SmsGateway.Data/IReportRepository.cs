using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.SmsGateway.Data
{
    public interface IReportRepository
    {
        Task<Report> InsertAsync(Report report);
        Task SaveChangesAsync();
    }
}