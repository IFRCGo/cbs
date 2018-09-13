// using System.Linq;
// using Dolittle.Queries;
// using Read.StaffUsers.Admin;
// using Read.StaffUsers.DataConsumer;
// using Read.StaffUsers.DataCoordinator;
// using Read.StaffUsers.DataOwner;
// using Read.StaffUsers.DataVerifier;
// using Read.StaffUsers.Models;
// using Read.StaffUsers.SystemConfigurator;

// namespace Read.StaffUsers.Queries
// {
//     public class AllStaffUsers : IQueryFor<BaseUser> 
//     {
//         private readonly IAdminRepository _adminRepository;
//         private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
//         private readonly IDataOwnerRepository _dataOwnerRepository;
//         private readonly IDataVerifierRepository _dataVerifierRepository;
//         private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
//         private readonly IDataConsumerRepository _dataConsumerRepository;

//         public AllStaffUsers(
//             IAdminRepository adminRepository,
//             IDataConsumerRepository dataConsumerRepository,
//             IDataCoordinatorRepository dataCoordinatorRepository,
//             IDataOwnerRepository dataOwnerRepository,
//             IDataVerifierRepository dataVerifierRepository,
//             ISystemConfiguratorRepository systemConfiguratorRepository)
//         {
//             _adminRepository = adminRepository;
//             _dataCoordinatorRepository = dataCoordinatorRepository;
//             _dataOwnerRepository = dataOwnerRepository;
//             _dataVerifierRepository = dataVerifierRepository;
//             _systemConfiguratorRepository = systemConfiguratorRepository;
//             _dataConsumerRepository = dataConsumerRepository;
//         }

//         public IQueryable<BaseUser> Query => 
//            (_adminRepository.Query.Select(_ => _).AsEnumerable()
//                 .Concat<BaseUser>(_dataConsumerRepository.Query.Select(_ => _)).AsEnumerable()
//                 .Concat(_dataCoordinatorRepository.Query.Select(_ => _)).AsEnumerable()
//                 .Concat(_dataOwnerRepository.Query.Select(_ => _)).AsEnumerable()
//                 .Concat(_dataVerifierRepository.Query.Select(_ => _)).AsEnumerable()
//                 .Concat(_systemConfiguratorRepository.Query.Select(_ => _)).AsEnumerable())
//                 .AsQueryable();

//     }
//     public class AllAdmins : IQueryFor<Models.Admin>
//     {
//         private readonly IAdminRepository _adminRepository;

//         public AllAdmins(
//             IAdminRepository adminRepository)
//         {
//             _adminRepository = adminRepository;
//         }

//         public IQueryable<Models.Admin> Query =>
//             _adminRepository.Query;

//     }

//     public class AllDataConsumers : IQueryFor<Models.DataConsumer>
//     {
//         private readonly IDataConsumerRepository _dataConsumerRepository;

//         public AllDataConsumers(
//             IDataConsumerRepository dataConsumerRepository)
//         {
//             _dataConsumerRepository = dataConsumerRepository;
//         }

//         public IQueryable<Models.DataConsumer> Query =>
//             _dataConsumerRepository.Query;
//     }

//     public class AllDataCoordinators : IQueryFor<Models.DataCoordinator>
//     {
//         private readonly IDataCoordinatorRepository _dataCoordinatorRepository;

//         public AllDataCoordinators(
//             IDataCoordinatorRepository dataCoordinatorRepository)
//         {
//             _dataCoordinatorRepository = dataCoordinatorRepository;
//         }

//         public IQueryable<Models.DataCoordinator> Query =>
//             _dataCoordinatorRepository.Query;
//     }

//     public class AllDataOwners : IQueryFor<Models.DataOwner>
//     {
//         private readonly IDataOwnerRepository _dataOwnerRepository;

//         public AllDataOwners(
//             IDataOwnerRepository dataOwnerRepository)
//         {
//             _dataOwnerRepository = dataOwnerRepository;
//         }

//         public IQueryable<Models.DataOwner> Query =>
//             _dataOwnerRepository.Query;
//     }

//     public class AllDataVerifiers : IQueryFor<Models.DataVerifier>
//     {
//         private readonly IDataVerifierRepository _dataVerifierRepository;

//         public AllDataVerifiers(
//             IDataVerifierRepository dataVerifierRepository)
//         {
//             _dataVerifierRepository = dataVerifierRepository;
//         }

//         public IQueryable<Models.DataVerifier> Query =>
//             _dataVerifierRepository.Query;
//     }

//     public class AllSystemConfigurator : IQueryFor<Models.SystemConfigurator>
//     {
//         private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;

//         public AllSystemConfigurator(
//             ISystemConfiguratorRepository systemConfiguratorRepository)
//         {
//             _systemConfiguratorRepository = systemConfiguratorRepository;
//         }

//         public IQueryable<Models.SystemConfigurator> Query =>
//             _systemConfiguratorRepository.Query;
//     }
// }