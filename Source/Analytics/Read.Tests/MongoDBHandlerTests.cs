using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Read.CaseReports;

namespace Read.Test
{
    [TestClass]
    public class MongoDBHandlerTests
    {
        public MongoDBHandler MongoDbHandler = new MongoDBHandler();
    
        [TestMethod]
        public void TestQueryable()
        {
            var someGenericClass = new SomeGenericClass("veryGenericKey", "veryGenericValue");

            someGenericClass.Id = ObjectId.Parse("5c9a0d8afe28b239e7da280d");

            MongoDbHandler.Insert(someGenericClass);

            var queryable = MongoDbHandler.GetQueryable<SomeGenericClass>().Where(x => x.Id == ObjectId.Parse("5c9a0d8afe28b239e7da280d")).ToList(); ;

            Assert.AreEqual(queryable.Count, 1);
        }

        [TestMethod]
        public void TestInsert()
        {
            var key = "war";
            SomeGenericClass y = new SomeGenericClass(key, "huh");

            MongoDbHandler.Insert(y);

            var queryable = MongoDbHandler.GetQueryable<SomeGenericClass>().Where(x => x.key == "war").ToList(); ;

            if (queryable.Count > 0)
            {
                var element = queryable[0];

                Assert.AreEqual(element.key, key);
            }
            else
            {
                throw new AssertFailedException("Insert failed, can't find inserted element");
            }

        }

        [TestMethod]
        public void TestUpdate()
        {
            SomeGenericClass genericClass = new SomeGenericClass("war", "huh");

            MongoDbHandler.Insert(genericClass);

            var queryable = MongoDbHandler.GetQueryable<SomeGenericClass>().Where(x => x.key == "war").ToList();

            var element = queryable[0];

            element.key = "newKey";
            element.value = "newValue";

            MongoDbHandler.Update(element);

            queryable = MongoDbHandler.GetQueryable<SomeGenericClass>().Where(x => x.key == "newKey").ToList();

            if (queryable.Count > 0)
            {
                element = queryable[0];

                Assert.AreEqual(element.key, "newKey");
            }
            else
            {
                throw new AssertFailedException("Update failed, couldn't find updated element");
            }
        }
    }

    public class SomeGenericClass : BaseReadModel
    {
        public SomeGenericClass(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string key { get; set; }

        public string value { get; set; }
    }
}
