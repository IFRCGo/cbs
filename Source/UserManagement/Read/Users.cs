using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
    public class Users : IUsers
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<StaffUser> _staffUserCollection;

        public Users(IMongoDatabase database)
        {
            _database = database;
            _staffUserCollection = database.GetCollection<StaffUser>("StaffUser");
        }

        public IEnumerable<StaffUser> GetAllStaffUsers()
        {
            return _staffUserCollection.FindSync(_ => true).ToList();
        }        

        public StaffUser GetStaffUserById(Guid id)
        {
            var user = _staffUserCollection.Find(c => c.Id == id).SingleOrDefault();
            if (user == null)
            {
                user = new StaffUser { Id = id };
                _staffUserCollection.InsertOne(user);
            }

            return user;
        }        

        public bool DeleteUserById(Guid id)
        {
            try
            {
                var user = _staffUserCollection.DeleteOne(c => c.Id == id);
                return user != null;

            }
            catch (Exception exp)
            {
                Console.WriteLine("Something went wron when deleting {0}. Exception: {1}", id, exp);
            }
            return false;
        }

        public void Save(StaffUser user)
        {
            _staffUserCollection.InsertOne(user);
        }        
    }
}