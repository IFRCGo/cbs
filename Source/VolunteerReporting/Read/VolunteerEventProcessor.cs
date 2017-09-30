 using Events.External;
 
 namespace Read
{
 public class VolunteerEventProcessors : Infrastructure.Events.IEventProcessor
    {
        readonly IVolunteers _volunteers;

        public VolunteerEventProcessors(IVolunteers volunteers)
        {
            _volunteers = volunteers;
        }

        public void Process(VolunteerRegistered @event)
        {
            var volunteer = _volunteers.GetById(@event.Id);
            if (volunteer == null){
                volunteer = new Volunteer{
                    Id = @event.Id
                };
                _volunteers.Create(volunteer);
                }
            else {
                //TODO: Update volunteer properties
                _volunteers.Update(volunteer);
                }
        }
    }
}