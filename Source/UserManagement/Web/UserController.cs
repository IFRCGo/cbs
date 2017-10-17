/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Domain;
using Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Events;
using Read;

namespace Web
{
    [Route("api/usermanagement/")]
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

        [HttpPost("staffuser")]
        public void Add([FromBody] AddStaffUser command)
        {
            _eventEmitter.Emit(Feature, new StaffUserAdded
            {
                Id = new Guid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age,
                Sex = command.Sex,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                MobilePhoneNumber = command.MobilePhoneNumber,
                Email = command.Email
            });
        }

        [HttpPost("datacollector")]
        public void Add([FromBody] AddDataCollector command)
        {
            _eventEmitter.Emit(Feature, new DataCollectorAdded
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age,
                Sex = command.Sex,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                MobilePhoneNumber = command.MobilePhoneNumber,
                Email = command.Email
            });
        }

        [HttpGet("staffusers")]
        public IEnumerable<StaffUser> GetAllStaffUsers()
        {
            Console.WriteLine("in staffusers");
            var users = _users.GetAllStaffUsers();
            return users;
        }

        [HttpGet("datacollectors")]
        public IEnumerable<DataCollector> GetAllDataCollectors()
        {
              Console.WriteLine("in datacollectors");
            var users = _users.GetAllDataCollectors();
            return users;
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}