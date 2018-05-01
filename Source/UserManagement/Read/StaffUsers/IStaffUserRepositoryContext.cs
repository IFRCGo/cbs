using Read.StaffUsers.Admin;
using Read.StaffUsers.DataConsumer;
using Read.StaffUsers.DataCoordinator;
using Read.StaffUsers.DataOwner;
using Read.StaffUsers.DataVerifier;
using Read.StaffUsers.SystemConfigurator;

namespace Read.StaffUsers
{
    public interface IStaffUserRepositoryContext
    {
        IAdminRepository AdminRepository { get; }
        IDataConsumerRepository DataConsumerRepository { get; }
        IDataCoordinatorRepository DataCoordinatorRepository { get; }
        IDataOwnerRepository DataOwnerRepository { get; }
        IDataVerifierRepository DataVerifierRepository { get; }
        ISystemConfiguratorRepository SystemConfiguratorRepository { get; }
    }
}