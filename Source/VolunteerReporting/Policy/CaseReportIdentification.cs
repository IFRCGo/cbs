using doLittle.Domain;
using doLittle.Events.Processing;
using Domain;
using Events.External;

namespace Policy
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        private readonly IAggregateRootRepository<CaseReporting> caseReportingAggregateRootRepository;

        public CaseReportIdentification(IAggregateRootRepository<CaseReporting> caseReportingAggregateRootRepository)
        {
            this.caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
        }

        public void Process(PhoneNumberAdded @event)
        {            
            //var repository = this.caseReportingAggregateRootRepository.Get()
        }
    }
}
