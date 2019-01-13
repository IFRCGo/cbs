/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("aebdf6aa-ea1a-48eb-b285-51d04308f5f0")]
    public class CreateProjectsHealthRiskTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
