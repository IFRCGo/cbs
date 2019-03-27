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

        public MongoDBHandler()
        {
        }

        public MongoDBHandler(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public IQueryable<CaseReport> getQueryable()
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(this.databaseName);
            var collection = database.GetCollection<CaseReport>("CaseReport");
            return collection.AsQueryable().AsQueryable();
        }

        public void insertRecordToDB(CaseReport dbEntry)
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");

            //get mongodb collection
            var collection = database.GetCollection<CaseReport>("CaseReport");
            collection.InsertOneAsync(dbEntry);
        }

        public void insertDataOwnerRecordToDB(DataOwner dbEntry)
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");

            //get mongodb collection
            var collection = database.GetCollection<DataOwner>("DataOwner");
            collection.InsertOneAsync(dbEntry);
        }

        //Add ability to update a record

        //Add ability to add any generic thing 
        public void insertGenericRecordToDB<T>(T objectToImplement)
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");

            //get mongodb collection
            var collection = database.GetCollection<T>(typeof(T).Name);
            collection.InsertOneAsync(objectToImplement);
        }


        public void updateRecordInDB<T>(T updatedElement, ObjectId id)
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");

            var collection = database.GetCollection<T>(typeof(T).Name);

            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            collection.ReplaceOne(filter, updatedElement, new UpdateOptions() { IsUpsert = false });
        }
    }
}
