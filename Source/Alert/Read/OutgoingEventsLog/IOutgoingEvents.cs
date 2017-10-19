using System;
using System.Collections.Generic;

namespace Read
{
    public interface IOutgoingEvents
    {
        void Save(OutgoingEvent outgoingEvent);
    }
}
