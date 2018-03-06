/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Read.UserFeatures;

namespace Domain.RuleImplementations
{
    public class UserRules : IUserRules
    {
        private readonly IUsers _users;

        public UserRules(IUsers users)
        {
            _users = users;
        }

        public bool IsUserExisting(Guid userId)
        {
            return _users.GetById(userId) != null;
        }
    }
}