using System;
using System.Collections.Generic;
using System.Text;

namespace Policies
{
    public interface IMessageTemplateService
    {
        string ComposeMessage(string templateType, Guid healthRiskId);
    }

    public class MessageTemplateService : IMessageTemplateService
    {
        public string ComposeMessage(string templateType, Guid healthRiskId)
        {
            return "";
        }
    }
}
