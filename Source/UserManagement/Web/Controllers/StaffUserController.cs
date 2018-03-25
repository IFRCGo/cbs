/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using doLittle.Read;
using Domain.StaffUser.Registering;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using MongoDB.Driver;
using Read.DataCollectors;
using Read.StaffUsers;
using Read.StaffUsers.Models;

namespace Web.Controllers
{
    [Route("api/staffusers")]
    public class StaffUserController : BaseController
    {
        private readonly IMongoDatabase _database;

        private readonly IRegisteringCommandHandlers _staffUserCommandHandler;

        private readonly IQueryCoordinator _queryCoordinator;

        public StaffUserController (
            IMongoDatabase database,
            IQueryCoordinator queryCoordinator,
            IRegisteringCommandHandlers stafffUserCommandHandler
            )
        {
            _database = database;
            _queryCoordinator = queryCoordinator;
            _staffUserCommandHandler = stafffUserCommandHandler;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _queryCoordinator.Execute(new AllStaffUsers<BaseUser>(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }

        [HttpGet("getadmins")]
        public IActionResult GetAllAdmins()
        {
            var result = _queryCoordinator.Execute(new AllStaffUsers<Admin>(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }


        //TODO: Does the Query-system acutally provide functionality for doing Queries async?
        //[HttpGet("getallasync")]
        //public async Task<IActionResult> GetAllStaffUsersAsync()
        //{
        //    var result = _queryCoordinator.Execute(new AllStaffUsersAsync<BaseUser>(_collection), new PagingInfo());

        //    if (result.Success)
        //    {
        //        return Ok(result.Items);
        //    }

        //    return new NotFoundResult();
        //}

        //TODO: Update to return CommandResult when the doLittle endpoint for queries and coommands is released :)
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