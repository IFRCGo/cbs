using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessages : IAutomaticReplyKeyMessages
    {
        public Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<AutomaticReplyKeyMessage> GetByProjectTypeAndLanguageAsync(Guid projectId, AutomaticReplyKeyMessage type, string language)
        {
            throw new NotImplementedException();
        }

        public void Save(AutomaticReplyKeyMessage keyMessage)
        {
            throw new NotImplementedException();
        }
    }
}
