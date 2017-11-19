using System;
using System.Collections.Generic;
using System.Text;
using Concepts;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessages : IDefaultAutomaticReplyKeyMessages
    {
        public Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyKeyMessageType type, string language)
        {
            throw new NotImplementedException();
        }

        public void Save(DefaultAutomaticReplyKeyMessage keyMessage)
        {
            throw new NotImplementedException();
        }
    }
}
