/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("984a0822-9baf-4daf-a43a-cc41645fb885")]
    public class CreateProjectTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
