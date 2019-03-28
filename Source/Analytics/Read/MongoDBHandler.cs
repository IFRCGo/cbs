using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Read
{
    //TODO: ADD ERROR HANDLING & REPORTING BACK TO CALLER
    public class MongoDBHandler
    {
        private string connectionString = "mongodb://localhost";
        private string databaseName = "read_model_database";
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBHandler()
        {
            _mongoDatabase = SetupDataBase();
        }

        public MongoDBHandler(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
            _mongoDatabase = SetupDataBase();
        }
        
        /**
         * Gets a queryable for a collection associated with a specific object type
        */
        public IQueryable<T> GetQueryable<T>() where T : BaseReadModel
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return collection.AsQueryable();
        }

        /**
         * Adds generic object to database into collection named as typeof the object
         */
        public void Insert<T>(T record) where T : BaseReadModel
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            collection.InsertOneAsync(record);
        }

        /*
         * Provides ability to update a database element T with a given ObjectID
         */
        public void Update<T>(T record, ObjectId id) where T : BaseReadModel
        {
            //Get collection associated with this object
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);

            //Create filter to get element to update
            var filter = Builders<T>.Filter.Eq("_id", id);

            //Replace DB element with updated element
            collection.ReplaceOne(filter, record, new UpdateOptions() { IsUpsert = false });
        }

        /*
         * gets an object of the databaseName using class level connectionstring & dbName
         */
        private IMongoDatabase SetupDataBase()
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(this.connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase(this.databaseName);

            return database;
        }
    }
}
