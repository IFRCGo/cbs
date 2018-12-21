/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands;

namespace Domain.Tests
{
    //[Artifact("43c5c245-40ff-426d-a6f7-226427c142bb")]
    public class CreateHealthRiskTestData : ICommand
    {
        public Guid Id { get; set; }
    }
}