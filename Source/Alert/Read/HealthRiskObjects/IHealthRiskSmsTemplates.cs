using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.HealthRiskObjects
{
    public interface IHealthRiskSmsTemplates
    {
        Task<HealtRiskSmsTemplate> GetSmsTemplate(Guid healthRiskId, string language);
        HealtRiskSmsTemplate GetById(Guid id);
        void Save(HealtRiskSmsTemplate entity);
        Task<List<HealtRiskSmsTemplate>> GetSmsTemplatesForHealthRisk(Guid healthRiskId);
    }
}