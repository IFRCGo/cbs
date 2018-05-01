using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Admin;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    
    public class AllStaffUsers : IQueryFor<BaseUser> 
    {
        private readonly IStaffUserRepositoryContext _context;

        public AllStaffUsers(IStaffUserRepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<BaseUser> Query => 
            _context.AdminRepository.Query.Select(_ => _)
                .Concat<BaseUser>(_context.DataConsumerRepository.Query.Select(_ => _))
                .Concat(_context.DataCoordinatorRepository.Query.Select(_ => _))
                .Concat(_context.DataOwnerRepository.Query.Select(_ => _))
                .Concat(_context.DataVerifierRepository.Query.Select(_ => _))
                .Concat(_context.SystemConfiguratorRepository.Query.Select(_ => _));

    }


    public class AllAdmins : IQueryFor<Models.Admin>
    {
        private readonly IAdminRepository _admins;

        public AllAdmins(IStaffUserRepositoryContext context)
        {
            _admins = context.AdminRepository;
        }

        public IQueryable<Models.Admin> Query => _admins.Query.Select(a => a);
    }
}