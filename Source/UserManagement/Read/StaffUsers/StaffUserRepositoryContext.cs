using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.SystemConfigurator;

namespace Read.StaffUsers
{
    public class StaffUserRepositoryContext : IStaffUserRepositoryContext
    {
        public IAdminRepository AdminRepository { get; }
        public IDataConsumerRepository DataConsumerRepository { get; }
        public IDataCoordinatorRepository DataCoordinatorRepository { get; }
        public IDataOwnerRepository DataOwnerRepository { get; }
        public IDataVerifierRepository DataVerifierRepository { get; }
        public ISystemConfiguratorRepository SystemConfiguratorRepository { get; }

        public StaffUserRepositoryContext(IAdminRepository admin, IDataConsumerRepository dataConsumer,
            IDataCoordinatorRepository dataCoordinator,
            IDataOwnerRepository dataOwner, IDataVerifierRepository dataVerifier,
            ISystemConfiguratorRepository systemConfigurator)
        {
            AdminRepository = admin;
            DataConsumerRepository = dataConsumer;
            DataCoordinatorRepository = dataCoordinator;
            DataOwnerRepository = dataOwner;
            DataVerifierRepository = dataVerifier;
            SystemConfiguratorRepository = systemConfigurator;
        }
    }
}