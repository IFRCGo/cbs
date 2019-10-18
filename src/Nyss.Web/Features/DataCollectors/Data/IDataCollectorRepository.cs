using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.Web.Features.DataCollectors.Data
{
    public interface IDataCollectorRepository
    {
        Task<DataCollector> GetDataCollectorByPhoneNumberAsync(string phoneNumber);
    }
}