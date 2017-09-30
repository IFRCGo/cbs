using System;

namespace Read
{
    public interface IVolunteers
    {
        Volunteer GetById(Guid id);
        void Create(Volunteer volunteer);
        void Update( Volunteer volunteer);
    }
}