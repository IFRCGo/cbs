/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Read.Users;
using System;
using Dolittle.ReadModels;

namespace Rules.Admin
{
    public class IsUserExisting : IRuleImplementationFor<Domain.Admin.IsUserExisting>
    {
        private readonly IReadModelRepositoryFor<User> _users;

        public IsUserExisting(IReadModelRepositoryFor<User> users)
        {
            _users = users; 
        }

        public Domain.Admin.IsUserExisting Rule => (Guid userId) =>
        {
            return _users.GetById(userId) != null;
        };
    }
}
