/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Queries;
using Dolittle.Queries.Coordination;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Read.StaffUsers;

namespace Web.Controllers
{
    [Route("api/staffusers")]
    public class StaffUserController : Controller
    {
        private readonly IMongoDatabase _database;
        private readonly IQueryCoordinator _queryCoordinator;

        public StaffUserController (
            IMongoDatabase database,
            IQueryCoordinator queryCoordinator)
        {
            _database = database;
            _queryCoordinator = queryCoordinator;
        }

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
   }
}