using System.Threading.Tasks;

namespace Nyss.Web.Features.HealthRisks.Data
{
    public interface IHealthRiskRepository
    {
        Task GetHealthRiskByCodeAsync(int code);
    }
}