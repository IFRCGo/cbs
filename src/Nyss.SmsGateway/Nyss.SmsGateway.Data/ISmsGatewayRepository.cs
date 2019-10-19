using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.SmsGateway.Data
{
    public interface ISmsGatewayRepository
    {
        Task<Report> InsertReportAsync(Report report);

        Task<DataCollector> GetDataCollectorFromPhoneNumberAsync(string phoneNumber);

        Task SaveChangesAsync();
    }
}