using System.Collections.Generic;

namespace Nyss.Web.Features.HealthRisks
{
    public interface IHealthRisksService
    {
        IEnumerable<HealthRiskViewModel> All();
        HealthRiskViewModel GetByCode(string code);
    }
}
