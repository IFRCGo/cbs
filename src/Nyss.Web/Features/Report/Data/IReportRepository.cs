using System.Threading.Tasks;

namespace Nyss.Web.Features.Report.Data
{
    public interface IReportRepository
    {
        Task<Nyss.Data.Models.Report> InsertReportAsync(Nyss.Data.Models.Report report);
        Task SaveChangesAsync();
    }
}