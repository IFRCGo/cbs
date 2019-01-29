/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.Project
{
    public class ProjectId : ConceptAs<Guid>
    {
        public static implicit operator ProjectId (Guid value) 
        {
            return new ProjectId{ Value = value };
        }
    }
}