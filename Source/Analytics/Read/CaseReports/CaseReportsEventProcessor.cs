using Dolittle.Collections;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Types;
using Events.VolunteerReporting.CaseReports;

namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<CaseReport> repository;
        private readonly IInstancesOf<ICalculateFromCaseReports> calculators;

        public CaseReportsEventProcessor(IReadModelRepositoryFor<CaseReport> repository, IInstancesOf<ICalculateFromCaseReports> calculators)
        {
            this.repository = repository;
            this.calculators = calculators;
        }
        
        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
            var caseReport = new CaseReport{
                NumberOfMalesAged5AndOlder = @event.NumberOfMalesAged5AndOlder,
                NumberOfFemalesAged5AndOlder = @event.NumberOfFemalesAged5AndOlder,
                NumberOfFemalesUnder5 = @event.NumberOfFemalesUnder5,
                NumberOfMalesUnder5 = @event.NumberOfMalesUnder5,
                Timestamp = @event.Timestamp,
                HealthRisk = @event.HealthRiskId,
                Longitude = @event.Longitude,
                Latitude = @event.Latitude
            };
            this.repository.Insert(caseReport);

            this.calculators.ForEach(c => c.Calculate(caseReport));
        }
    }

}
