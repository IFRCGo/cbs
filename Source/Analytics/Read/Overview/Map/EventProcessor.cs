using Dolittle.Events.Processing;
using Events.Reporting.CaseReports;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Overview.Map
{
    public class EventProcessor : ICanProcessEvents
    {

        readonly IReadModelRepositoryFor<Outbreak> _outbreakRepository;

        public EventProcessor(IReadModelRepositoryFor<Outbreak> outbreakRepository){
            this._outbreakRepository = outbreakRepository;
        }

        [EventProcessor("f52d714c-ca1a-460f-abff-f585d7f98df8")]
        public void Process(CaseReportReceived @event){
            
        }
    }
}
