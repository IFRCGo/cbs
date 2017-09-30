using Events.External;
using Read;

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
        if (volunteer == null)
        {
            volunteer = new Volunteer
            {
                Id = @event.Id
            };
            _volunteers.Create(volunteer);
        }
        else
        {
            //Update properties of volunteer here
            _volunteers.Update(volunteer);
        }
    }
}