/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Events
{
    /// <summary>
    /// Defines a producer of <see cref="EventEnvelope">event envelopes</see>
    /// </summary>
    public interface IEventEnvelopeProducer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        EventEnvelope CreateFor(EventOrigin origin, IEvent @event);
    }
}