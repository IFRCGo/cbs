/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Concepts;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents the unique identifier for an event correlation
    /// </summary>
    public class EventCorrelationId : ConceptAs<Guid>
    {
        /// <summary>
        /// Implicitly convert from <see cref="Guid"/> to <see cref="EventCorrelationId"/>
        /// </summary>
        /// <param name="id">Id in the form of a <see cref="Guid"/></param>
        public static implicit operator EventCorrelationId(Guid id) 
        {
            return new EventCorrelationId { Value = id };
        }
    }
}