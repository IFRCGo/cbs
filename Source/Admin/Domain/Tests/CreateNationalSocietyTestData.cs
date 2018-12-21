/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("3da39c7f-e549-4507-ba28-745927d294f")]
    public class CreateNationalSocietyTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}
