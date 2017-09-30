using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Read
{
    public class Users : IUsers
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<StaffUser> _staffUserCollection;
        readonly IMongoCollection<VolunteerUser> _volunteerUserCollection;

        public Users(IMongoDatabase database)
        {
            _database = database;
            _staffUserCollection = database.GetCollection<StaffUser>("StaffUser");
            _volunteerUserCollection = database.GetCollection<VolunteerUser>("VolunteerUser");
        }

        public IEnumerable<StaffUser> GetAllStaffUsers()
        {
            return _staffUserCollection.FindSync(_ => true).ToList();
        }

        public IEnumerable<VolunteerUser> GetAllVolunteerUsers()
        {
            return _volunteerUserCollection.FindSync(_ => true).ToList();
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

        public VolunteerUser GetVolunteerUserById(Guid id)
        {
            var user = _volunteerUserCollection.Find(c => c.Id == id).SingleOrDefault();
            if (user == null)
            {
                user = new VolunteerUser { Id = id };
                _volunteerUserCollection.InsertOne(user);
            }

            return user;
        }

        public void Save(StaffUser user)
        {
            _staffUserCollection.InsertOne(user);
        }

        public void Save(VolunteerUser user)
        {
            _volunteerUserCollection.InsertOne(user);
        }
    }
}