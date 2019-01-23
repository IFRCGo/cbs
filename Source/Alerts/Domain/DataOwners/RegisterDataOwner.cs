/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/


using Concepts.AlertRules;
using Dolittle.Commands;

namespace Domain.DataOwners
{
    public class RegisterDataOwner : ICommand
    {
        public DataOwnerId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
