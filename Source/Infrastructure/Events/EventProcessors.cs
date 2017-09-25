/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Types;

namespace Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventProcessors"/>
    /// </summary>
    public class EventProcessors : IEventProcessors
    {
        /// <summary>
        /// The name of the process method looked for by convention
        /// </summary>
        public const string ProcessMethodName = "Process";

        readonly IInstancesOf<IEventProcessor> _eventProcessors;

        /// <summary>
        /// Initializes a new instance of <see cref="EventProcessors"/>
        /// </summary>
        /// <param name="eventProcessors"></param>
        public EventProcessors(IInstancesOf<IEventProcessor> eventProcessors) 
        {
            _eventProcessors = eventProcessors;
        }

        /// <inheritdoc/>
        public void Process(EventEnvelope @event)
        {
            
        }
    }
}