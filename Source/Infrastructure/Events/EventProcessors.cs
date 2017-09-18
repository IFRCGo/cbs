/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Types;

namespace Events
{
    public class EventProcessors : IEventProcessors
    {
        public const string ProcessMethodName = "Process";

        readonly IInstancesOf<IEventProcessor> _eventProcessors;

        public EventProcessors(IInstancesOf<IEventProcessor> eventProcessors) 
        {
            _eventProcessors = eventProcessors;
        }

        public void Process(EventEnvelope @event)
        {
            
        }
    }
}