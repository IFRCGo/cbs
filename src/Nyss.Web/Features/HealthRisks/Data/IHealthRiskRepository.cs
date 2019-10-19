using System.Threading.Tasks;
using Nyss.Data.Models;

namespace Nyss.Web.Features.HealthRisks.Data
{
    public interface IHealthRiskRepository
    {
        Task<HealthRisk> GetHealthRiskByCodeAsync(int code);
    }
}