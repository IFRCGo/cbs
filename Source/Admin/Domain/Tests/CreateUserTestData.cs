/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("fa742b5c-15aa-441a-991c-61d154898a30")]
    public class CreateUserTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
