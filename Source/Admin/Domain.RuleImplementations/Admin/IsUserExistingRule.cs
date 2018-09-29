/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Domain.Admin;
using Infrastructure.Rules;
using Read.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RuleImplementations.Admin
{
    public class IsUserExistingRule : IRuleImplementationFor<UserExist>
    {
        private readonly IUsers _users;

        public IsUserExistingRule(IUsers users)
        {
            _users = users; 
        }

        public UserExist Rule => (Guid userId) =>
        {
            return _users.GetById(userId) != null;
        };
    }
}
