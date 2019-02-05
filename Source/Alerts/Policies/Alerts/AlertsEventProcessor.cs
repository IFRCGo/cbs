using System.Collections.Generic;
using System.Linq;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Alerts;
using Read.CaseReports;
using Read.DataOwners;

namespace Policies.Alerts
{
    public class AlertsEventProcessor : ICanProcessEvents
    {
        private readonly IMailSender _mailSender;
        private readonly IReadModelRepositoryFor<DataOwner> _dataOwnersRepository;
        private readonly IReadModelRepositoryFor<Case> _casesRepository;

        public AlertsEventProcessor(
            IMailSender mailSender, 
            IReadModelRepositoryFor<DataOwner> dataOwnersRepository,
            IReadModelRepositoryFor<Case> casesRepository)
        {
            this._mailSender = mailSender;
            this._dataOwnersRepository = dataOwnersRepository;
            this._casesRepository = casesRepository;
        }
        
        [EventProcessor("042ec98c-ed13-061c-f175-c15b3a9363f2")]
        public void Process(AlertOpened @event)
        {
            List<DataOwner> owners = _dataOwnersRepository.Query.ToList();

            var caseItem = _casesRepository.GetById(@event.Cases[0]);
            foreach (var owner in owners)
            {
                string message = $"Dear {owner.Name},\nAlert opened on health risk {caseItem.HealthRiskNumber} with {@event.Cases.Length} case(s). Please follow up using the Reporting module in CBS.";
                _mailSender.Send(owner.Email, $"CBS Alert opened", message);
            }
        }
        
    }
}
