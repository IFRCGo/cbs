/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using doLittle.Domain;
using Domain;
using Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using doLittle.Events;
using Read;
using Infrastructure.AspNet;
using Read.StaffUsers;

namespace Web
{
    [Route("api/staffusers")]
    public class StaffUserController : BaseController
    {
        private readonly IStaffUsers _users;
        private readonly IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser> _staffUser;

        public StaffUserController(
            IStaffUsers users,
            IAggregateRootRepositoryFor<Domain.StaffUser.StaffUser> staffUser)
        {
            _users = users;
            _staffUser = staffUser;
        }

        [HttpPost("add")]
        public void Add([FromBody] AddStaffUser command)
        {
            var id = Guid.NewGuid();
            var role = command.Role;
            // TODO: Should produce command(?) that produces the right events
            Apply(id, new StaffUserAdded
            {
                Id = id,
                FullName = command.FullName,
                DisplayName = command.DisplayName,
                Age = command.Age,
                Sex = command.Sex,
                Location = command.Location,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                MobilePhoneNumber = command.MobilePhoneNumber,
                Email = command.Email
            });
        }
        
        [HttpGet("staffusers")]
        public async Task<IEnumerable<StaffUser>> GetAllStaffUsers()
        {
            Console.WriteLine("in staffusers");
            var users = await _users.GetAllAsync();
            return users;
        }

        [HttpPost("update/{id}")]
        public void Update([FromBody] AddStaffUser command, Guid id)
        {
            //TODO: Should produce the command(?) that produces the right events
            Apply(id, new StaffUserAdded
            {
                Id = id,
                FullName = command.FullName,
                DisplayName = command.DisplayName,
                Age = command.Age,
                Sex = command.Sex,
                Location = command.Location,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                MobilePhoneNumber = command.MobilePhoneNumber,
                Email = command.Email
            });
        }
        [HttpDelete("delete/{id}")]
        public async void Delete(Guid id)
        {
            var role = (await _users.GetByIdAsync(id)).Role;
            Apply(id, new StaffUserDeleted
            {
                Id = id,
                Role =  (int)role
            });
        }
    }
}