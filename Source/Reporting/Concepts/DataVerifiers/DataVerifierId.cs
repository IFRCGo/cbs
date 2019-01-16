/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
using Dolittle.Concepts;
using System;

namespace Concepts.DataVerifiers
{
    public class DataVerifierId : ConceptAs<Guid>
    {
        public static readonly DataVerifierId NotSet = Guid.Empty;
        
        public static implicit operator DataVerifierId(Guid value)
        {
            return new DataVerifierId {Value = value};
        }
         public static implicit operator DataVerifierId(string id)
        {
            return new DataVerifierId { Value = Guid.Parse(id) };
        }
    }
}
