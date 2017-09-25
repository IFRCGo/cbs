/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Events
{
    /// <summary>
    /// Represents an envelope to keep metadata and an actual <see cref="IEvent"/>
    /// </summary>
    public class EventEnvelope
    {
        /// <summary>
        /// Gets the <see cref="EventSequenceNumber"/> for the <see cref="IEvent"/>
        /// </summary>
        public EventSequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the <see cref="EventCorrelationId"/> for the <see cref="IEvent"/>
        /// </summary>
        public EventCorrelationId CorrelationId { get; }

        /// <summary>
        /// Gets the <see cref="EventOrigin"/> for the <see cref="IEvent"/>
        /// </summary>
        public EventOrigin Origin { get; }

        /// <summary>
        /// Gets the actual <see cref="IEvent"/>
        /// </summary>
        public IEvent Event { get; }
    }
}