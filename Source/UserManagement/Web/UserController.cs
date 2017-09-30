/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using MongoDB.Driver.Core.Misc;

namespace Web
{
    [Route("api/usermanagement/user")]
    public class UserController : Controller
    {
        public static readonly Infrastructure.Application.Feature Feature = "User";

        readonly IUsers _users;
        readonly IEventEmitter _eventEmitter;
        readonly ILogger<UserController> _logger;

        public UserController(
            IUsers users,
            IEventEmitter eventEmitter,
            ILogger<UserController> logger)
        {
            _users = users;
            _eventEmitter = eventEmitter;
            _logger = logger;
        }


        [HttpGet]
        public User Get()
        {
            return new User();
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}