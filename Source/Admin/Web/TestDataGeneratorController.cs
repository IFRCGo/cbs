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
using Events.External;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;

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
            CreateHealthRisks();
        }

        [HttpGet("nationalsocieties")]
        public void CreateNationalSociety()
        {
            var _collection = _database.GetCollection<NationalSociety>("NationalSociety");
            _collection.DeleteMany(v => true);

            var societies = JsonConvert.DeserializeObject<NationalSocietyCreated[]>(File.ReadAllText("./TestData/NationalSocieties.json"));
			foreach (var society in societies)
				_eventEmitter.Emit("NationalSociety", society);
        }

        [HttpGet("users")]
        public void CreateUsers()
        {
            var _collection = _database.GetCollection<User>("Users");
            _collection.DeleteMany(v => true);

            var societies = JsonConvert.DeserializeObject<NationalSocietyCreated[]>(File.ReadAllText("./TestData/NationalSocieties.json"));
            var users = JsonConvert.DeserializeObject<UserCreated[]>(File.ReadAllText("./TestData/Names.json"));
            int i = 0;

            foreach (var user in users)
            {
                // Make sure we have a valid National Society ID
                if (!societies.Any(v=>v.Id == user.NationalSocietyId))
                    user.NationalSocietyId = societies[i++ % societies.Length].Id;

                _eventEmitter.Emit("User", user);
            }
        }

        [HttpGet("createhealthrisks")]
        public void CreateHealthRisks()
        {
            var _collection = _database.GetCollection<NationalSociety>("HealthRisk");
            _collection.DeleteMany(v => true);

            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(File.ReadAllText("./TestData/HealthRisks.json"));
            foreach (var risk in risks)
                _eventEmitter.Emit("HealthRisk", risk);
        }

        [HttpGet("createhealthrisksjson")]
        public void CreateHealthRisksJson()
        {
            ConvertSeparatedFileWithHeadersToJson(
                "./TestData/CBS Diseases - Events.tsv",
                "./TestData/HealthRisks.json",
                "\t",
                (columnNames, values) =>
                {
                    var threshold = values[Array.IndexOf(columnNames, "Threshold")];
                    return new HealthRiskCreated()
                    {
                        Id = Guid.NewGuid(),
                        ReadableId = int.Parse(values[Array.IndexOf(columnNames, "UID")]),
                        Name = values[Array.IndexOf(columnNames, "Health Risk")],
                        Threshold = string.IsNullOrEmpty(threshold) ? (int?)null : int.Parse(threshold),
                        ConfirmedCase = values[Array.IndexOf(columnNames, "Confirmed Case")],
                        ProbableCase = values[Array.IndexOf(columnNames, "Probable case")],
                        SuspectedCase = values[Array.IndexOf(columnNames, "Suspected Case")],
                        CommunityCase = values[Array.IndexOf(columnNames, "Community Case")],
                        Note = values[Array.IndexOf(columnNames, "Note")],
                        KeyMessage = values[Array.IndexOf(columnNames, "Key Message")]
                    };
                });

            //var lines = File.ReadAllLines("./TestData/CBS Diseases - Events.tsv");
            //string[] columnNames = lines.First().Split("\t");
            //List<HealthRiskCreated> risks = new List<HealthRiskCreated>();
            //foreach (var line in lines.Skip(1))
            //{
            //    string[] values = line.Split("\t");
            //    var risk = new HealthRiskCreated()
            //    {
            //        Id = Guid.NewGuid(),
            //        ReadableId = int.Parse(values[Array.IndexOf(columnNames, "UID")]),
            //        Name = values[Array.IndexOf(columnNames, "Health Risk")],
            //        Threshold = values[Array.IndexOf(columnNames, "Threshold")]
            //    };
            //    risks.Add(risk);
            //}
            //File.WriteAllText("./TestData/HealthRisks.json", JsonConvert.SerializeObject(risks));

        }

        private void ConvertSeparatedFileWithHeadersToJson<T>(string inputFilePath, string outputFilePath, string separator, Func<string[], string[], T> callback)
        {
            var lines = File.ReadAllLines(inputFilePath);
            string[] columnNames = lines.First().Split(separator);
            var list = new List<T>();
            foreach (string line in lines.Skip(1))
            {
                string[] values = line.Split(separator);
                list.Add(callback(columnNames, values));
            }
            File.WriteAllText(outputFilePath, JsonConvert.SerializeObject(list.ToArray()));
        }
    }
}
