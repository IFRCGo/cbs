using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.Models;
using Read.StaffUsers.SystemConfigurator;

namespace Read.StaffUsers
{
    
    public class AllStaffUsers : IQueryFor<BaseUser> 
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
        private readonly IDataOwnerRepository _dataOwnerRepository;
        private readonly IDataVerifierRepository _dataVerifierRepository;
        private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
        private readonly IDataConsumerRepository _dataConsumerRepository;

        public AllStaffUsers(
            IAdminRepository adminRepository,
            IDataConsumerRepository dataConsumerRepository,
            IDataCoordinatorRepository dataCoordinatorRepository,
            IDataOwnerRepository dataOwnerRepository,
            IDataVerifierRepository dataVerifierRepository,
            ISystemConfiguratorRepository systemConfiguratorRepository)
        {
            _adminRepository = adminRepository;
            _dataCoordinatorRepository = dataCoordinatorRepository;
            _dataOwnerRepository = dataOwnerRepository;
            _dataVerifierRepository = dataVerifierRepository;
            _systemConfiguratorRepository = systemConfiguratorRepository;
            _dataConsumerRepository = dataConsumerRepository;
        }

        public IQueryable<BaseUser> Query => 
            _adminRepository.Query.Select(_ => _)
                .Concat<BaseUser>(_dataConsumerRepository.Query.Select(_ => _))
                .Concat(_dataCoordinatorRepository.Query.Select(_ => _))
                .Concat(_dataOwnerRepository.Query.Select(_ => _))
                .Concat(_dataVerifierRepository.Query.Select(_ => _))
                .Concat(_systemConfiguratorRepository.Query.Select(_ => _));

    }


    /*
    public class AllAdmins : IQueryFor<Models.Admin>
    {
        private readonly IAdminRepository _admins;

        public AllAdmins(IStaffUserRepositoryContext context)
        {
            _admins = context.AdminRepository;
        }

        public IQueryable<Models.Admin> Query => _admins.Query.Select(a => a);
    }*/
}