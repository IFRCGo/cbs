/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.NationalSocieties;
using Concepts.Users;
using Dolittle.Commands;

namespace Domain.Users
{
    public class CreateUser : ICommand
    {
        public UserId Id { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }

        public string Country { get; set; }
        public NationalSocietyId NationalSocietyId { get; set; }

    }
}
