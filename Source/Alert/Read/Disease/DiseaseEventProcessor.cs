using Events.External;

namespace Read.Disease
{
    public class DiseaseEventProcessor : Infrastructure.Events.IEventProcessor
    {
        private readonly IDiseases _diseases;

        public DiseaseEventProcessor(IDiseases diseases)
        {
            _diseases = diseases;
        }

        public void Process(DiseaseCreatedEvent @event)
        {
            var user = _diseases.GetById(@event.Id);
            if (user == null)
            {
                user = new Read.Disease.Disease()
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Code = @event.Code
                };
            }
            else
            {
                user.Id = @event.Id;
                user.Name = @event.Name;
                user.Code = @event.Code;
            }
            _diseases.Save(user);
        }
    }
}
