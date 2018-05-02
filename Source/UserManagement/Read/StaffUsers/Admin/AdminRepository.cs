using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Read.StaffUsers.Admin
{
    public class AdminRepository : ReadModelRepositoryForStaffUser<Models.Admin>,
        IAdminRepository
    {

        public AdminRepository(IMongoDatabase database)
            : base(database, database.GetCollection<Models.Admin>("Admins"))
        {
        }
    }
}