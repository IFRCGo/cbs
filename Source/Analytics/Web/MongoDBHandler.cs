using System;
using System.Collections.Generic;
using System.Data.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Web
{
    public class MongoDBHandler
    {
        private readonly string connectionString = "mongodb://localhost";

        public MongoDBHandler()
        {
            this.setUpConnectionAsync();
        }
        
        private void setUpConnectionAsync()
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("read_model_database");  
            var collection = database.GetCollection<BsonDocument>("CaseReport");
            var list = collection.Find(new BsonDocument()).ToEnumerable();
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public void insertRecordToDB(DbCaseEntry dbEntry)
        {
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");
            
            //get mongodb collection
            var collection = database.GetCollection<DbCaseEntry>("CaseReport");           
            collection.InsertOneAsync(dbEntry);           
        }

        public void deleteAllRecordsFromDB()
        {
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");
            database.DropCollection("CaseReport");
        }

        private void getFilteredResultsFromDB()
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("read_model_database");
            var collection = database.GetCollection<BsonDocument>("CaseReport");
            var list = collection.Find(new BsonDocument()).ToEnumerable();
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }

/*            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            IMongoDatabase database = client.GetDatabase("read_model_database");
            string[] test = new string[] { "x", "x1" };

            var dbEntry = new DbCaseEntry(2, 2, 2, 2, test, new Guid(), 0.0, 0.0);

            //get mongodb collection
            var collection = database.GetCollection<DbCaseEntry>("CaseReport");
            collection.InsertOneAsync(dbEntry);*/
        }
    }
}
