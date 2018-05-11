using System;
using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Admin;

namespace Read.StaffUsers.Queries
{
    public class StaffUserById<T> : IQueryFor<T>
        where T : Models.Admin
    {
        private readonly IAdminRepository _repository;

        public Guid StaffUserId { get; set; }

        public StaffUserById(IAdminRepository repository, Guid staffUserId)
        {
            _repository = repository;
            StaffUserId = staffUserId;
        }

        public IQueryable<Models.Admin> Query => _repository.GetMany(u => u.StaffUserId == StaffUserId).AsQueryable();
    }
}