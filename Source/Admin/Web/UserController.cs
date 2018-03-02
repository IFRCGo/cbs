/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.UserFeatures;

namespace Web
{
    [Route("api/user")]
    public class UserController : Controller
    {
        readonly IUsers _users;
        readonly ILogger<ProjectController> _logger;

        public UserController(
            IUsers users,
            ILogger<ProjectController> logger)
        {
            _users = users;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get(Guid nationalSocietyId)
        {
            return await _users.GetByNationalSocietyId(nationalSocietyId);
        }
    }
}