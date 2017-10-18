/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read;
using Read.UserFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
    [Route("api/user")]
    public class UserController : Controller
    {
        readonly IUsers _users;
        readonly IEventEmitter _eventEmitter;
        readonly ILogger<ProjectController> _logger;

        public UserController(
            IUsers users,
            IEventEmitter eventEmitter,
            ILogger<ProjectController> logger)
        {
            _users = users;
            _eventEmitter = eventEmitter;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get(Guid nationalSocietyId)
        {
            return await _users.GetByNationalSocietyId(nationalSocietyId);
        }
    }
}