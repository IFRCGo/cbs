/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.StaffUser.Registering;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using Read.StaffUsers;
using Read.StaffUsers.Models;

namespace Web.Controllers
{
    [Route("api/staffusers")]
    public class StaffUserController : BaseController
    {
        private readonly IStaffUsers _users;

        private readonly IRegisteringCommandHandlers _staffUserCommandHandler;

        public StaffUserController (
            IStaffUsers users,
            IRegisteringCommandHandlers stafffUserCommandHandler
            )
        {
            _users = users;
            _staffUserCommandHandler = stafffUserCommandHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<BaseUser>> GetAllStaffUsers()
        {
            var users = await _users.GetAllAsync<BaseUser>();
            return users;
        }


        [HttpPost("register/admin")]
        public void RegisterAdmin([FromBody] RegisterNewAdminUser command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }
        [HttpPost("register/systemconfigurator")]
        public void RegisterAdmin([FromBody] RegisterNewSystemConfigurator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }
        [HttpPost("register/datacordinator")]
        public void RegisterAdmin([FromBody] RegisterNewDataCoordinator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }
        [HttpPost("register/dataowner")]
        public void RegisterAdmin([FromBody] RegisterNewDataOwner command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }
        [HttpPost("register/staffdataconsumer")]
        public void RegisterAdmin([FromBody] RegisterNewStaffDataConsumer command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }
        [HttpPost("register/staffdataverifier")]
        public void RegisterAdmin([FromBody] RegisterNewStaffDataVerifier command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            _staffUserCommandHandler.Handle(command);
        }

        //TODO: Implement when we have decided on how updating should work for the staffusers
        //[HttpPost("update")]
        //public void Update([FromBody] UpdateStaffUser command)
        //{
        //    // of the staffuser types to ensure that the correct information is 
        //    // given?
        //    _staffUserCommandHandler.Handle(command);

        //}
        //[HttpDelete("delete")]
        //public void Delete([FromBody] DeleteStaffUser command)
        //{
        //    _staffUserCommandHandler.Handle(command);
        //}
}
}