/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Events
{
    /// <summary>
    /// 
    /// </summary>
    public class EventEnvelope
    {
        public EventSequenceNumber SequenceNumber { get; }
        public EventCorrelationId CorrelationId { get; }
        public EventOrigin Origin { get; }
        public IEvent Event { get; }
    }
}