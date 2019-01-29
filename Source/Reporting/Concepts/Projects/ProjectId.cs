/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.Projects
{
    public class ProjectId : ConceptAs<Guid>
    {
        public static ProjectId NotSet = Guid.Empty;
        public static implicit operator ProjectId (Guid value) 
        {
            return new ProjectId{ Value = value };
        }

        public static implicit operator ProjectId(string id)
        {
            return new ProjectId { Value = Guid.Parse(id) };
        }
    }
}