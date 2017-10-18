using System;
using System.Collections.Generic;
using System.Text;

namespace Events.External
{
    public class MessageTemplateCreated
    {
        public Guid Id { get; set; }

        public Guid HealthRiskId { get; set; }

        public string EventTriggerType { get; set; }

        public string LanguageName { get; set; }

        public string Text { get; set; }
    }
}
