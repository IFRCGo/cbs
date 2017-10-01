using Events;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Read;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Web
{

    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController
    {
        private IEventEmitter _eventEmitter;
        private IMongoDatabase _database;

        private Guid[] _nationalSocietyIds = new Guid[] { new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"), new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"), new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e") };
        private Guid[] _userIds = new Guid[] { new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"), new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"), new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e"), new Guid("9835cf5d-0b43-463e-b8f7-3bc94b911679"), new Guid("38ec7f61-aa60-4ed1-8b08-41783423e1e8"), new Guid("70736cc9-1194-44ac-a5e5-fb4b7f165b09"), new Guid("c5d92ded-e42f-439f-a559-63d353b73223") };

        public TestDataGeneratorController(IEventEmitter eventEmitter, IMongoDatabase database)
        {
            _eventEmitter = eventEmitter;
            _database = database;
        }



        [HttpGet("all")]
        public void CreateAll()
        {
            CreateNationalSociety();
            CreateUsers();
        }

        [HttpGet("nationalsocieties")]
        public void CreateNationalSociety()
        {
            var _collection = _database.GetCollection<NationalSociety>("NationalSociety");
            _collection.DeleteMany(v => true);

            int i = 1;
            foreach (var id in _nationalSocietyIds)
                _eventEmitter.Emit("NationalSecurity", new NationalSocietyCreated() { Id = id, Name = $"National Sociity #{i++}" });
        }

        [HttpGet("users")]
        public void CreateUsers()
        {
            var _collection = _database.GetCollection<NationalSociety>("Users");
            _collection.DeleteMany(v => true);
            
            var users = JsonConvert.DeserializeObject<UserCreated[]>(File.ReadAllText(".\\TestData\\Names.json"));
            foreach (var user in users)
                _eventEmitter.Emit("User", user);
        }
    }
}
