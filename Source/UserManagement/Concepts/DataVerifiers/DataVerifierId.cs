/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.DataVerifiers
{
    public class DataVerifierId : ConceptAs<Guid>
    {
        public static implicit operator DataVerifierId(Guid value)
        {
            return new DataVerifierId { Value = value };
        }
    }
}
