using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.HealthRiskObjects
{
    public class HealthRiskSmsTemplates : Repository<HealtRiskSmsTemplate>, IHealthRiskSmsTemplates
    {
        public HealthRiskSmsTemplates(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }

        public async Task<HealtRiskSmsTemplate> GetSmsTemplate(Guid healthRiskId, string language)
        {
            return await _collection.Find(x => x.HealthRiskId == healthRiskId && x.LanguageName == language).SingleOrDefaultAsync();
        }

        public async Task<List<HealtRiskSmsTemplate>> GetSmsTemplatesForHealthRisk(Guid healthRiskId)
        {
            return await _collection.Find(x => x.HealthRiskId == healthRiskId).ToListAsync();
        }
    }
}
