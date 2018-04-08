/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using doLittle.Read;
using Domain.StaffUser.Registering;
using Domain.StaffUser.Roles;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using MongoDB.Driver;
using Read.DataCollectors;
using Read.StaffUsers;
using Read.StaffUsers.Models;
using Admin = Read.StaffUsers.Models.Admin;
using DataConsumer = Read.StaffUsers.Models.DataConsumer;
using DataCoordinator = Read.StaffUsers.Models.DataCoordinator;
using DataOwner = Read.StaffUsers.Models.DataOwner;
using DataVerifier = Read.StaffUsers.Models.DataVerifier;
using SystemConfigurator = Read.StaffUsers.Models.SystemConfigurator;

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

        #region Get All Users

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return GetAllStaffUsers<BaseUser>();
        }

        [HttpGet("getadmins")]
        public IActionResult GetAllAdmins()
        {
            return GetAllStaffUsers<Admin>();
        }

        [HttpGet("getdataconsumers")]
        public IActionResult GetAllDataConsumers()
        {
            return GetAllStaffUsers<DataConsumer>();
        }

        [HttpGet("getdatacoordinators")]
        public IActionResult GetAllDataCoordinator()
        {
            return GetAllStaffUsers<DataCoordinator>();
        }

        [HttpGet("getdataowners")]
        public IActionResult GetAllDataOwners()
        {
            return GetAllStaffUsers<DataOwner>();
        }

        [HttpGet("getdataverifiers")]
        public IActionResult GetAllDataVerifiers()
        {
            return GetAllStaffUsers<DataVerifier>();
        }

        [HttpGet("getsystemconfigurators")]
        public IActionResult GetAllSystemConfigurators()
        {
            return GetAllStaffUsers<SystemConfigurator>();
        }

        #endregion

        #region Get By Id

        [HttpGet("getuser/{id}")]
        public IActionResult GetById(Guid id)
        {
            return GetStaffUserById<BaseUser>(id);
        }

        [HttpGet("getadmin/{id}")]
        public IActionResult GetAdminById(Guid id)
        {
            return GetStaffUserById<Admin>(id);
        }

        [HttpGet("getdataconsumer/{id}")]
        public IActionResult GetDataConsumerById(Guid id)
        {
            return GetStaffUserById<DataConsumer>(id);
        }

        [HttpGet("getdatacoordinator/{id}")]
        public IActionResult GetDataCoordinatorById(Guid id)
        {
            return GetStaffUserById<DataCoordinator>(id);
        }

        [HttpGet("getdataowner/{id}")]
        public IActionResult GetDataOwnerById(Guid id)
        {
            return GetStaffUserById<DataOwner>(id);
        }

        [HttpGet("getdataverifier/{id}")]
        public IActionResult GetDataVerifierById(Guid id)
        {
            return GetStaffUserById<DataVerifier>(id);
        }

        [HttpGet("getsystemconfigurator/{id}")]
        public IActionResult GetSystemConfiguratorById(Guid id)
        {
            return GetStaffUserById<SystemConfigurator>(id);
        }

        #endregion

        #region Register

        //TODO: Update to return CommandResult when the doLittle endpoint for queries and coommands is released :)

        [HttpPost("register/admin")]
        public IActionResult RegisterAdmin([FromBody] RegisterNewAdminUser command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            RegisterStaffUser<RegisterNewAdminUser, Domain.StaffUser.Roles.Admin>(command);

            return Ok();
        }

        [HttpPost("register/systemconfigurator")]
        public IActionResult RegisterSystemConfigurator([FromBody] RegisterNewSystemConfigurator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            RegisterStaffUser<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>(command);

            return Ok();
        }

        [HttpPost("register/datacordinator")]
        public IActionResult RegisterDatacordinator([FromBody] RegisterNewDataCoordinator command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            RegisterStaffUser<RegisterNewDataCoordinator, Domain.StaffUser.Roles.DataCoordinator>(command);

            return Ok();
        }

        [HttpPost("register/dataowner")]
        public IActionResult RegisterDataOwner([FromBody] RegisterNewDataOwner command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            RegisterStaffUser<RegisterNewDataOwner, Domain.StaffUser.Roles.DataOwner>(command);

            return Ok();
        }

        [HttpPost("register/staffdataconsumer")]
        public IActionResult RegisterDataConsumer([FromBody] RegisterNewStaffDataConsumer command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            RegisterStaffUser<RegisterNewStaffDataConsumer, Domain.StaffUser.Roles.DataConsumer>(command);

            return Ok();
        }

        [HttpPost("register/staffdataverifier")]
        public IActionResult RegisterDataVerifier([FromBody] RegisterNewStaffDataVerifier command)
        {
            command.Role.StaffUserId = Guid.NewGuid();
            
            RegisterStaffUser<RegisterNewStaffDataVerifier, Domain.StaffUser.Roles.DataVerifier>(command);

            return Ok();
        }

        #endregion

        #region Update Methods

        [HttpPost("update/admin")]
        public IActionResult UpdateAdmin([FromBody] RegisterNewAdminUser command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPost("update/systemconfigurator")]
        public IActionResult UpdateSystemConfigurator([FromBody] RegisterNewSystemConfigurator command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPost("update/datacordinator")]
        public IActionResult UpdaterDataCordinator([FromBody] RegisterNewDataCoordinator command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPost("update/dataowner")]
        public IActionResult UpdateDataOwner([FromBody] RegisterNewDataOwner command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPost("update/staffdataconsumer")]
        public IActionResult UpdateDataConsumer([FromBody] RegisterNewStaffDataConsumer command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPost("update/staffdataverifier")]
        public IActionResult UpdateDataVerifier([FromBody] RegisterNewStaffDataVerifier command)
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command);

            return Ok();
        }

        #endregion

        #region Private Methods

        private IActionResult GetAllStaffUsers<T>()
            where T : BaseUser
        {
            var result = _queryCoordinator.Execute(new AllStaffUsers<T>(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }

        private IActionResult GetStaffUserById<T>(Guid id)
            where T : BaseUser
        {
            var result = _queryCoordinator.Execute(new StaffUserById<T>(_database, id), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }

        private void RegisterStaffUser<TRegistration, TRole>(TRegistration command)
            where TRegistration : NewStaffRegistration<TRole>
            where TRole : StaffRole
        {
            command.Role.StaffUserId = Guid.NewGuid();
            command.IsNewRegistration = true;
            //TODO: Hmm, a working workaround this is... Though, I think it would be better to do this in AggregateRoot 
            command.RegisteredAt = DateTimeOffset.UtcNow;
            _staffUserCommandHandler.Handle(command as dynamic);
        }

        private void UpdateStaffUser<TRegistration, TRole>(TRegistration command)
            where TRegistration : NewStaffRegistration<TRole>
            where TRole : StaffRole
        {
            command.IsNewRegistration = false;
            _staffUserCommandHandler.Handle(command as dynamic);
        }

        #endregion
    }
}