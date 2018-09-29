// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/
// using System;
// using Dolittle.Queries;
// using Dolittle.Queries.Coordination;
// using Microsoft.AspNetCore.Mvc;
// using Read.StaffUsers.Admin;
// using Read.StaffUsers.DataConsumer;
// using Read.StaffUsers.DataCoordinator;
// using Read.StaffUsers.DataOwner;
// using Read.StaffUsers.DataVerifier;
// using Read.StaffUsers.Queries;
// using Read.StaffUsers.SystemConfigurator;

// namespace Web.Controllers
// {
//     [Route("api/staffusers")]
//     public class StaffUserController : Controller
//     {
//         private readonly IAdminRepository _adminRepository;
//         private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
//         private readonly IDataOwnerRepository _dataOwnerRepository;
//         private readonly IDataVerifierRepository _dataVerifierRepository;
//         private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
//         private readonly IDataConsumerRepository _dataConsumerRepository;

//         private readonly IQueryCoordinator _queryCoordinator;

//         public StaffUserController (
//             IQueryCoordinator queryCoordinator,
//             IAdminRepository adminRepository,
//             IDataConsumerRepository dataConsumerRepository,
//             IDataCoordinatorRepository dataCoordinatorRepository,
//             IDataOwnerRepository dataOwnerRepository,
//             IDataVerifierRepository dataVerifierRepository,
//             ISystemConfiguratorRepository systemConfiguratorRepository)
//         {
//             _queryCoordinator = queryCoordinator;
//             _adminRepository = adminRepository;
//             _dataCoordinatorRepository = dataCoordinatorRepository;
//             _dataOwnerRepository = dataOwnerRepository;
//             _dataVerifierRepository = dataVerifierRepository;
//             _systemConfiguratorRepository = systemConfiguratorRepository;
//             _dataConsumerRepository = dataConsumerRepository;
//         }

//         [HttpGet]
//         public IActionResult GetAllUsers()
//         {
//             var res = _queryCoordinator.Execute(
//                 new AllStaffUsers(_adminRepository, _dataConsumerRepository, _dataCoordinatorRepository,
//                     _dataOwnerRepository, _dataVerifierRepository, _systemConfiguratorRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("admin")]
//         public IActionResult GetAllAdmins()
//         {
//             var res = _queryCoordinator.Execute(new AllAdmins(_adminRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("dataconsumer")]
//         public IActionResult GetAllDataConsumers()
//         {
//             var res = _queryCoordinator.Execute(new AllDataConsumers(_dataConsumerRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("datacoordinator")]
//         public IActionResult GetAllDataCoordinator()
//         {
//             var res = _queryCoordinator.Execute(new AllDataCoordinators(_dataCoordinatorRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("dataowner")]
//         public IActionResult GetAllDataOwners()
//         {
//             var res = _queryCoordinator.Execute(new AllDataOwners(_dataOwnerRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("dataverifier")]
//         public IActionResult GetAllDataVerifiers()
//         {
//             var res = _queryCoordinator.Execute(new AllDataVerifiers(_dataVerifierRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }

//         [HttpGet("systemconfigurator")]
//         public IActionResult GetAllSystemConfigurators()
//         {
//             var res = _queryCoordinator.Execute(new AllSystemConfigurator(_systemConfiguratorRepository), new PagingInfo());

//             if (res.Success)
//                 return Ok(res.Items);
//             return StatusCode(500);
//         }


//         [HttpGet("{id}")]
//         public IActionResult GetById(Guid id)
//         {
//             var res = _queryCoordinator.Execute(new StaffUserById(_adminRepository, _dataConsumerRepository, _dataCoordinatorRepository,
//                 _dataOwnerRepository, _dataVerifierRepository, _systemConfiguratorRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("admin/{id}")]
//         public IActionResult GetAdminById(Guid id)
//         {
//             var res = _queryCoordinator.Execute(new AdminById(_adminRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("dataconsumer/{id}")]
//         public IActionResult GetDataConsumerById(Guid id)
//         {

//             var res = _queryCoordinator.Execute(new DataConsumerById(_dataConsumerRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("datacoordinator/{id}")]
//         public IActionResult GetDataCoordinatorById(Guid id)
//         {
//             var res = _queryCoordinator.Execute(new DataCoordinatorById(_dataCoordinatorRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("dataowner/{id}")]
//         public IActionResult GetDataOwnerById(Guid id)
//         {

//             var res = _queryCoordinator.Execute(new DataOwnerById(_dataOwnerRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("dataverifier/{id}")]
//         public IActionResult GetDataVerifierById(Guid id)
//         {
//             var res = _queryCoordinator.Execute(new DataVerifierById(_dataVerifierRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();
//         }

//         [HttpGet("systemconfigurator/{id}")]
//         public IActionResult GetSystemConfiguratorById(Guid id)
//         {
//             var res = _queryCoordinator.Execute(new SystemConfiguratorById(_systemConfiguratorRepository){StaffUserId = id}, new PagingInfo());

//             if (!res.Success) return StatusCode(500);
//             if (res.TotalItems > 0)
//                 return Ok(res.Items);
//             return NotFound();

//         }
//     }
// }