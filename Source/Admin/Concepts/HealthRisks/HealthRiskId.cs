/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Runtime.Events;

namespace Concepts.HealthRisks
{
    public class HealthRiskId : EventSourceId
    {
        public static implicit operator HealthRiskId(Guid id) => new HealthRiskId { Value = id };
    }
}