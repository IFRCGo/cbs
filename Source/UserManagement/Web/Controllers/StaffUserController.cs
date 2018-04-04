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
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("register/systemconfigurator")]
        public void RegisterSystemConfigurator([FromBody] RegisterNewSystemConfigurator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("register/datacordinator")]
        public void RegisterDatacordinator([FromBody] RegisterNewDataCoordinator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("register/dataowner")]
        public void RegisterDataOwner([FromBody] RegisterNewDataOwner command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("register/staffdataconsumer")]
        public void RegisterDataConsumer([FromBody] RegisterNewStaffDataConsumer command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("register/staffdataverifier")]
        public void RegisterDataVerifier([FromBody] RegisterNewStaffDataVerifier command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/admin")]
        public void UpdateAdmin([FromBody] RegisterNewAdminUser command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/systemconfigurator")]
        public void UpdateSystemConfigurator([FromBody] RegisterNewSystemConfigurator command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/datacordinator")]
        public void UpdaterDataCordinator([FromBody] RegisterNewDataCoordinator command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/dataowner")]
        public void UpdateDataOwner([FromBody] RegisterNewDataOwner command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/staffdataconsumer")]
        public void UpdateDataConsumer([FromBody] RegisterNewStaffDataConsumer command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        [HttpPost("update/staffdataverifier")]
        public void UpdateDataVerifier([FromBody] RegisterNewStaffDataVerifier command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);
        }

        //[HttpDelete("delete")]
        //public void Delete([FromBody] DeleteStaffUser command)
        //{
        //    _staffUserCommandHandler.Handle(command);
        //}
    }
}