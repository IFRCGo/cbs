using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages
    {
        Task<AutomaticReplyKeyMessage> GetByProjectTypeAndLanguageAsync(Guid projectId, AutomaticReplyKeyMessage type, string language);
        void Save(AutomaticReplyKeyMessage keyMessage);
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync();
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(Guid projectId);
    }
}
