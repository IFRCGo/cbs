using System;
using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.Models;
using Read.StaffUsers.SystemConfigurator;

namespace Read.StaffUsers.Queries
{
    public class StaffUserById : IQueryFor<BaseUser>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDataCoordinatorRepository _dataCoordinatorRepository;
        private readonly IDataOwnerRepository _dataOwnerRepository;
        private readonly IDataVerifierRepository _dataVerifierRepository;
        private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;
        private readonly IDataConsumerRepository _dataConsumerRepository;

        public Guid StaffUserId { get; set; }
        public StaffUserById(
            IAdminRepository adminRepository,
            IDataConsumerRepository dataConsumerRepository,
            IDataCoordinatorRepository dataCoordinatorRepository,
            IDataOwnerRepository dataOwnerRepository,
            IDataVerifierRepository dataVerifierRepository,
            ISystemConfiguratorRepository systemConfiguratorRepository
            )
        {
            _adminRepository = adminRepository;
            _dataCoordinatorRepository = dataCoordinatorRepository;
            _dataOwnerRepository = dataOwnerRepository;
            _dataVerifierRepository = dataVerifierRepository;
            _systemConfiguratorRepository = systemConfiguratorRepository;
            _dataConsumerRepository = dataConsumerRepository;
            
        }

        public IQueryable<BaseUser> Query =>
            (_adminRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId).AsEnumerable()
                .Concat<BaseUser>(_dataConsumerRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId)).AsEnumerable()
                .Concat(_dataCoordinatorRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId)).AsEnumerable()
                .Concat(_dataOwnerRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId)).AsEnumerable()
                .Concat(_dataVerifierRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId)).AsEnumerable()
                .Concat(_systemConfiguratorRepository.Query.Select(_ => _).Where(u => u.Id == StaffUserId)).AsEnumerable())
                .AsQueryable();

    }
    public class AdminById : IQueryFor<Models.Admin>
    {
        private readonly IAdminRepository _adminRepository;

        public Guid StaffUserId { get; set; }
        public AdminById(
            IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IQueryable<Models.Admin> Query =>
            _adminRepository.Query.Where(u => u.Id == StaffUserId);

    }

    public class DataConsumerById : IQueryFor<Models.DataConsumer>
    {
        private readonly IDataConsumerRepository _dataConsumerRepository;


        public Guid StaffUserId { get; set; }
        public DataConsumerById(
            IDataConsumerRepository dataConsumerRepository)
        {
            _dataConsumerRepository = dataConsumerRepository;
        }

        public IQueryable<Models.DataConsumer> Query =>
            _dataConsumerRepository.Query.Where(u => u.Id == StaffUserId);
    }

    public class DataCoordinatorById : IQueryFor<Models.DataCoordinator>
    {
        private readonly IDataCoordinatorRepository _dataCoordinatorRepository;

        public Guid StaffUserId { get; set; }

        public DataCoordinatorById(
            IDataCoordinatorRepository dataCoordinatorRepository)
        {
            _dataCoordinatorRepository = dataCoordinatorRepository;
        }

        public IQueryable<Models.DataCoordinator> Query =>
            _dataCoordinatorRepository.Query.Where(u => u.Id == StaffUserId);
    }

    public class DataOwnerById : IQueryFor<Models.DataOwner>
    {
        private readonly IDataOwnerRepository _dataOwnerRepository;


        public Guid StaffUserId { get; set; }
        public DataOwnerById(
            IDataOwnerRepository dataOwnerRepository)
        {
            _dataOwnerRepository = dataOwnerRepository;
        }

        public IQueryable<Models.DataOwner> Query =>
            _dataOwnerRepository.Query.Where(u => u.Id == StaffUserId);
    }

    public class DataVerifierById : IQueryFor<Models.DataVerifier>
    {
        private readonly IDataVerifierRepository _dataVerifierRepository;


        public Guid StaffUserId { get; set; }
        public DataVerifierById(
            IDataVerifierRepository dataVerifierRepository)
        {
            _dataVerifierRepository = dataVerifierRepository;
        }

        public IQueryable<Models.DataVerifier> Query =>
            _dataVerifierRepository.Query.Where(u => u.Id == StaffUserId);
    }

    public class SystemConfiguratorById : IQueryFor<Models.SystemConfigurator>
    {
        private readonly ISystemConfiguratorRepository _systemConfiguratorRepository;


        public Guid StaffUserId { get; set; }
        public SystemConfiguratorById(
            ISystemConfiguratorRepository systemConfiguratorRepository)
        {
            _systemConfiguratorRepository = systemConfiguratorRepository;
        }

        public IQueryable<Models.SystemConfigurator> Query =>
            _systemConfiguratorRepository.Query.Where(u => u.Id == StaffUserId);
    }
}