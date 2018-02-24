/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Domain;
using Domain.StaffUser.CommandHandlers;
using Domain.StaffUser.Commands;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using Read.StaffUsers;

namespace Web.Controllers
{
    [Route("api/staffusers")]
    public class StaffUserController : BaseController
    {
        private readonly IStaffUsers _users;

        private readonly StaffUserCommandHandler _staffUserCommandHandler;

        public StaffUserController (
            IStaffUsers users,
            StaffUserCommandHandler stafffUserCommandHandler
            )
        {
            _users = users;
            _staffUserCommandHandler = stafffUserCommandHandler;
        }

        [HttpPost("add")]
        public void Add([FromBody] AddStaffUser command)
        {
            _staffUserCommandHandler.Handle(command);
            
        }
        
        [HttpGet("staffusers")]
        public async Task<IEnumerable<StaffUser>> GetAllStaffUsers()
        {
            var users = await _users.GetAllAsync();
            return users;
        }

        [HttpPost("update/{id}")]
        public void Update([FromBody] AddStaffUser command, Guid id)
        {
            //TODO: Maybe make a
            _staffUserCommandHandler.Handle(command);
            /*
            //TODO: Should produce the command(?) that produces the right events
            Apply(id, new StaffUserAdded
            {
                Id = id,
                FullName = command.FullName,
                DisplayName = command.DisplayName,
                YearOfBirth = command.YearOfBirth,
                Sex = command.Sex,
                Location = command.Location,
                NationalSociety = command.NationalSociety,
                PreferredLanguage = command.PreferredLanguage,
                MobilePhoneNumber = command.MobilePhoneNumber,
                Email = command.Email
            });
            */
        }
        [HttpDelete("delete")]
        public void Delete([FromBody] DeleteStaffUser command)
        {
            _staffUserCommandHandler.Handle(command);
            /*
            var role = (await _users.GetByIdAsync(id)).Role;
            Apply(id, new StaffUserDeleted
            {
                Id = id,
                Role =  (int)role
            });
            */
        }
    }
}