/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Commands;
using System;
using Concepts;

namespace Domain.Commands
{
    public class RemovePhoneNumber : ICommand
    {
        //TODO: If we make a descent input validator for this command we can have it this way
        //which seems intuitive to me.

        // Validator will check that if DataCollectorId == null then StaffUserId and Role != null
        // If StaffUserId == null or Role == null then DataCollectorId != null 
        public Guid? DataCollectorId { get; set; }
        public Guid? StaffUserId { get; set; }
        public Role? Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}
