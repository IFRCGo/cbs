using System;
using System.Collections.Generic;
using System.Text;

namespace Read.HealthRiskObjects
{
    public class HealtRiskSmsTemplate : Entity
    {
        public Guid HealthRiskId { get; set; }
        public string EventTriggerType { get; set; }
        public string LanguageName { get; set; }
        public string Text { get; set; }
    }
}
