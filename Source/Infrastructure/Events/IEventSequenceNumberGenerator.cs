/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Infrastructure.Events
{
    /// <summary>
    /// Defines a <see cref="EventSequenceNumber"/> generator
    /// </summary>
    public interface IEventSequenceNumberGenerator
    {
        /// <summary>
        /// Get the next number in the sequence for an <see cref="IEvent"/> from a specific <see cref="EventOrigin"/>
        /// </summary>
        /// <param name="origin"><see cref="EventOrigin">Origin</see> of the <see cref="IEvent"/></param>
        /// <param name="event">Actual <see cref="IEvent"/></param>
        /// <returns></returns>
        EventSequenceNumber NextFor(EventOrigin origin, IEvent @event);
    }
}