using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages
    {
        DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyKeyMessageType type, string language);
        void Save(DefaultAutomaticReplyKeyMessage keyMessage);
        Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync();
    }
}
