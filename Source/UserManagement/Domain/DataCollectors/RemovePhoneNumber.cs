/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    public class RemovePhoneNumber : ICommand
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
