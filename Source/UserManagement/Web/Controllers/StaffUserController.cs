/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using doLittle.Read;
using Domain.StaffUser.Registering;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.AspNet;
using MongoDB.Driver;
using Read.StaffUsers;
using Web.Models;

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
            return GetAllStaffUsers<Read.StaffUsers.Models.BaseUser>();
        }

        [HttpGet("admin")]
        public IActionResult GetAllAdmins()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.Admin>();
        }

        [HttpGet("dataconsumer")]
        public IActionResult GetAllDataConsumers()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.DataConsumer>();
        }

        [HttpGet("datacoordinator")]
        public IActionResult GetAllDataCoordinator()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.DataCoordinator>();
        }

        [HttpGet("dataowner")]
        public IActionResult GetAllDataOwners()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.DataOwner>();
        }

        [HttpGet("dataverifier")]
        public IActionResult GetAllDataVerifiers()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.DataVerifier>();
        }

        [HttpGet("systemconfigurator")]
        public IActionResult GetAllSystemConfigurators()
        {
            return GetAllStaffUsers<Read.StaffUsers.Models.SystemConfigurator>();
        }

        #endregion

        #region Get By Id

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.BaseUser>(id);
        }

        [HttpGet("admin/{id}")]
        public IActionResult GetAdminById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.Admin>(id);
        }

        [HttpGet("dataconsumer/{id}")]
        public IActionResult GetDataConsumerById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.DataConsumer>(id);
        }

        [HttpGet("datacoordinator/{id}")]
        public IActionResult GetDataCoordinatorById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.DataCoordinator>(id);
        }

        [HttpGet("dataowner/{id}")]
        public IActionResult GetDataOwnerById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.DataOwner>(id);
        }

        [HttpGet("dataverifier/{id}")]
        public IActionResult GetDataVerifierById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.DataVerifier>(id);
        }

        [HttpGet("systemconfigurator/{id}")]
        public IActionResult GetSystemConfiguratorById(Guid id)
        {
            return GetStaffUserById<Read.StaffUsers.Models.SystemConfigurator>(id);
        }

        #endregion

        #region Register

        [HttpPost("admin")]
        public IActionResult RegisterAdmin([FromBody] Admin admin)
        {
            var command = new RegisterNewAdminUser
            {
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    StaffUserId = Guid.NewGuid(),
                    FullName = admin.FullName,
                    DisplayName = admin.DisplayName,
                    Email = admin.Email
                },
            };

            RegisterStaffUser<RegisterNewAdminUser, Domain.StaffUser.Roles.Admin>(command);

            return Ok();
        }

        [HttpPost("systemconfigurator")]
        public IActionResult RegisterSystemConfigurator([FromBody] SystemConfigurator systemConfigurator)
        {
            var command = new RegisterNewSystemConfigurator()
            {
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    StaffUserId = Guid.NewGuid(),
                    FullName = systemConfigurator.FullName,
                    DisplayName = systemConfigurator.DisplayName,
                    Email = systemConfigurator.Email,
                    PhoneNumbers = systemConfigurator.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = systemConfigurator.PreferredLanguage,
                    NationalSociety = systemConfigurator.NationalSociety,
                    Sex = systemConfigurator.Sex,
                    AssignedNationalSocieties = systemConfigurator.AssignedNationalSocieties,
                    BirthYear = systemConfigurator.BirthYear
                },
            };


            RegisterStaffUser<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>(command);

            return Ok();
        }

        [HttpPost("datacordinator")]
        public IActionResult RegisterDatacordinator([FromBody] DataCoordinator dataCoordinator)
        {
            var command = new RegisterNewDataCoordinator()
            {
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    StaffUserId = Guid.NewGuid(),
                    FullName = dataCoordinator.FullName,
                    DisplayName = dataCoordinator.DisplayName,
                    Email = dataCoordinator.Email,
                    PhoneNumbers = dataCoordinator.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = dataCoordinator.PreferredLanguage,
                    NationalSociety = dataCoordinator.NationalSociety,
                    Sex = dataCoordinator.Sex,
                    AssignedNationalSocieties = dataCoordinator.AssignedNationalSocieties,
                    BirthYear = dataCoordinator.BirthYear
                }
            };
            RegisterStaffUser<RegisterNewDataCoordinator, Domain.StaffUser.Roles.DataCoordinator>(command);

            return Ok();
        }

        [HttpPost("dataowner")]
        public IActionResult RegisterDataOwner([FromBody] DataOwner dataOwner)
        {
            var command = new RegisterNewDataOwner()
            {
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    StaffUserId = Guid.NewGuid(),
                    FullName = dataOwner.FullName,
                    DisplayName = dataOwner.DisplayName,
                    Email = dataOwner.Email,
                    PhoneNumbers = dataOwner.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = dataOwner.PreferredLanguage,
                    NationalSociety = dataOwner.NationalSociety,
                    Sex = dataOwner.Sex,
                    BirthYear = dataOwner.BirthYear,
                    DutyStation = dataOwner.DutyStation,
                    Position = dataOwner.Position
                }
            };

            RegisterStaffUser<RegisterNewDataOwner, Domain.StaffUser.Roles.DataOwner>(command);

            return Ok();
        }

        [HttpPost("staffdataconsumer")]
        public IActionResult RegisterDataConsumer([FromBody] DataConsumer dataConsumer)
        {
            var command = new RegisterNewStaffDataConsumer
            {
                IsNewRegistration = true,
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    FullName = dataConsumer.FullName,
                    DisplayName = dataConsumer.DisplayName,
                    Email = dataConsumer.Email,
                    PreferredLanguage = dataConsumer.PreferredLanguage,
                    NationalSociety = dataConsumer.NationalSociety,
                    Sex = dataConsumer.Sex,
                    BirthYear = dataConsumer.BirthYear,
                    Location = dataConsumer.Location
                }
            };
            RegisterStaffUser<RegisterNewStaffDataConsumer, Domain.StaffUser.Roles.DataConsumer>(command);

            return Ok();
        }

        [HttpPost("staffdataverifier")]
        public IActionResult RegisterDataVerifier([FromBody] DataVerifier dataVerifier)
        {
            var command = new RegisterNewStaffDataVerifier
            {
                RegisteredAt = DateTimeOffset.UtcNow,
                Role =
                {
                    FullName = dataVerifier.FullName,
                    DisplayName = dataVerifier.DisplayName,
                    Email = dataVerifier.Email,
                    PreferredLanguage = dataVerifier.PreferredLanguage,
                    NationalSociety = dataVerifier.NationalSociety,
                    Sex = dataVerifier.Sex,
                    BirthYear = dataVerifier.BirthYear,
                    Location = dataVerifier.Location,
                    PhoneNumbers = dataVerifier.PhoneNumbers.Select(p => p.Value)
                }
            };
            RegisterStaffUser<RegisterNewStaffDataVerifier, Domain.StaffUser.Roles.DataVerifier>(command);

            return Ok();
        }

        #endregion

        #region Update Methods

        [HttpPut("admin")]
        public IActionResult UpdateAdmin([FromBody] Admin admin)
        {
            var command = new RegisterNewAdminUser
            {
                RegisteredAt = admin.RegistrationDate,
                Role =
                {
                    StaffUserId = admin.StaffUserId,
                    FullName = admin.FullName,
                    DisplayName = admin.DisplayName,
                    Email = admin.Email
                }
            };
            UpdateStaffUser<RegisterNewAdminUser, Domain.StaffUser.Roles.Admin>(command);

            return Ok();
        }

        [HttpPut("systemconfigurator")]
        public IActionResult UpdateSystemConfigurator([FromBody] SystemConfigurator systemConfigurator)
        {
            var command = new RegisterNewSystemConfigurator
            {
                RegisteredAt = systemConfigurator.RegistrationDate,
                Role =
                {
                    StaffUserId = systemConfigurator.StaffUserId,
                    FullName = systemConfigurator.FullName,
                    DisplayName = systemConfigurator.DisplayName,
                    Email = systemConfigurator.Email,
                    PhoneNumbers = systemConfigurator.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = systemConfigurator.PreferredLanguage,
                    NationalSociety = systemConfigurator.NationalSociety,
                    Sex = systemConfigurator.Sex,
                    AssignedNationalSocieties = systemConfigurator.AssignedNationalSocieties,
                    BirthYear = systemConfigurator.BirthYear
                },
            };
            UpdateStaffUser<RegisterNewSystemConfigurator, Domain.StaffUser.Roles.SystemConfigurator>(command);

            return Ok();
        }

        [HttpPut("datacordinator")]
        public IActionResult UpdaterDataCordinator([FromBody] DataCoordinator dataCoordinator)
        {
            var command = new RegisterNewDataCoordinator
            {
                RegisteredAt = dataCoordinator.RegistrationDate,
                Role =
                {
                    StaffUserId = dataCoordinator.StaffUserId,
                    FullName = dataCoordinator.FullName,
                    DisplayName = dataCoordinator.DisplayName,
                    Email = dataCoordinator.Email,
                    PhoneNumbers = dataCoordinator.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = dataCoordinator.PreferredLanguage,
                    NationalSociety = dataCoordinator.NationalSociety,
                    Sex = dataCoordinator.Sex,
                    AssignedNationalSocieties = dataCoordinator.AssignedNationalSocieties,
                    BirthYear = dataCoordinator.BirthYear
                }
            };
            UpdateStaffUser<RegisterNewDataCoordinator, Domain.StaffUser.Roles.DataCoordinator>(command);

            return Ok();
        }

        [HttpPut("dataowner")]
        public IActionResult UpdateDataOwner([FromBody] DataOwner dataOwner)
        {
            var command = new RegisterNewDataOwner
            {
                RegisteredAt = dataOwner.RegistrationDate,
                Role =
                {
                    StaffUserId = dataOwner.StaffUserId,
                    FullName = dataOwner.FullName,
                    DisplayName = dataOwner.DisplayName,
                    Email = dataOwner.Email,
                    PhoneNumbers = dataOwner.PhoneNumbers.Select(p => p.Value),
                    PreferredLanguage = dataOwner.PreferredLanguage,
                    NationalSociety = dataOwner.NationalSociety,
                    Sex = dataOwner.Sex,
                    BirthYear = dataOwner.BirthYear,
                    DutyStation = dataOwner.DutyStation,
                    Position = dataOwner.Position
                }
            };

            UpdateStaffUser<RegisterNewDataOwner, Domain.StaffUser.Roles.DataOwner>(command);

            return Ok();
        }

        [HttpPut("staffdataconsumer")]
        public IActionResult UpdateDataConsumer([FromBody] DataConsumer dataConsumer)
        {
            var command = new RegisterNewStaffDataConsumer
            {
                RegisteredAt = dataConsumer.RegistrationDate,
                Role =
                {
                    StaffUserId = dataConsumer.StaffUserId,
                    FullName = dataConsumer.FullName,
                    DisplayName = dataConsumer.DisplayName,
                    Email = dataConsumer.Email,
                    PreferredLanguage = dataConsumer.PreferredLanguage,
                    NationalSociety = dataConsumer.NationalSociety,
                    Sex = dataConsumer.Sex,
                    BirthYear = dataConsumer.BirthYear,
                    Location = dataConsumer.Location
                }
            };
            UpdateStaffUser<RegisterNewStaffDataConsumer, Domain.StaffUser.Roles.DataConsumer>(command);

            return Ok();
        }

        [HttpPut("staffdataverifier")]
        public IActionResult UpdateDataVerifier([FromBody] DataVerifier dataVerifier)
        {
            var command = new RegisterNewStaffDataVerifier
            {
                RegisteredAt = dataVerifier.RegistrationDate,
                Role =
                {
                    StaffUserId = dataVerifier.StaffUserId,
                    FullName = dataVerifier.FullName,
                    DisplayName = dataVerifier.DisplayName,
                    Email = dataVerifier.Email,
                    PreferredLanguage = dataVerifier.PreferredLanguage,
                    NationalSociety = dataVerifier.NationalSociety,
                    Sex = dataVerifier.Sex,
                    BirthYear = dataVerifier.BirthYear,
                    Location = dataVerifier.Location,
                    PhoneNumbers = dataVerifier.PhoneNumbers.Select(p => p.Value)
                }
            };
            UpdateStaffUser<RegisterNewStaffDataVerifier, Domain.StaffUser.Roles.DataVerifier>(command);

            return Ok();
        }

        #endregion

        #region Private Methods

        private IActionResult GetAllStaffUsers<T>()
            where T : Read.StaffUsers.Models.BaseUser
        {
            var result = _queryCoordinator.Execute(new AllStaffUsers<T>(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }

        private IActionResult GetStaffUserById<T>(Guid id)
            where T : Read.StaffUsers.Models.BaseUser
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
            where TRole : Domain.StaffUser.Roles.StaffRole
        {
            command.IsNewRegistration = true;
            command.Role.StaffUserId = Guid.NewGuid();
            command.RegisteredAt = DateTimeOffset.UtcNow;

            _staffUserCommandHandler.Handle(command as dynamic);
        }

        private void UpdateStaffUser<TRegistration, TRole>(TRegistration command)
            where TRegistration : NewStaffRegistration<TRole>
            where TRole : Domain.StaffUser.Roles.StaffRole
        {
            command.IsNewRegistration = false;

            _staffUserCommandHandler.Handle(command as dynamic);
        }

        #endregion
    }
}