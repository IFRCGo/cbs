using System;
using MongoDB.Driver;

namespace Read
{
    public class Volunteers : IVolunteers
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Volunteer> _collection;

        public Volunteers(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<Volunteer>("Volunteer");
        }

        public Volunteer GetById(Guid id)
        {
           return _collection.Find(v => v.Id == id).SingleOrDefault();
        }

        public void Create(Volunteer volunteer)
        {
            _collection.InsertOne(volunteer);
        }

        public void Update(Volunteer volunteer)
        {
            var filter = Builders<Volunteer>.Filter.Eq(c => c.Id, volunteer.Id);
            _collection.ReplaceOne(filter, volunteer);
        }
    }
}