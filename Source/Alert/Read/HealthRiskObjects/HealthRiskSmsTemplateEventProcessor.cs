using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.External;

namespace Read.HealthRiskObjects
{
    public class HealthRiskSmsTemplateEventProcessor : Infrastructure.Events.IEventProcessor
    {
        private readonly IHealthRiskSmsTemplates _healthRiskSmsTemplates;

        public HealthRiskSmsTemplateEventProcessor(IHealthRiskSmsTemplates healthRiskSmsTemplates)
        {
            _healthRiskSmsTemplates = healthRiskSmsTemplates;
        }

        public async void Process(MessageTemplateCreated @event)
        {
            var templates = await _healthRiskSmsTemplates.GetSmsTemplatesForHealthRisk(@event.HealthRiskId);
            if (templates == null || !templates.Any(t => t.LanguageName.ToLower().Equals(@event.LanguageName.ToLower())))
            {
                _healthRiskSmsTemplates.Save(new HealtRiskSmsTemplate()
                {
                    EventTriggerType = @event.EventTriggerType,
                    HealthRiskId = @event.HealthRiskId,
                    Id = @event.Id,
                    LanguageName = @event.LanguageName,
                    Text = @event.Text
                });
            }
            else
            {
                var template = templates.Single(t => t.LanguageName.ToLower().Equals(@event.LanguageName.ToLower()));
                template.Text = @event.Text;
                _healthRiskSmsTemplates.Save(template);
            }
        }
    }
}
