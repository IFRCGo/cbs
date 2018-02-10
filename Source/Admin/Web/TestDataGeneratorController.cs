using Events;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Driver;
using Newtonsoft.Json;
using Events.External;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;
using Infrastructure.AspNet;
using Newtonsoft.Json.Linq;
using Read.ProjectFeatures;

namespace Web
{

    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : BaseController
    {
        private IMongoDatabase _database;

        private Guid[] _nationalSocietyIds = new Guid[] { new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"), new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"), new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e") };
        private Guid[] _userIds = new Guid[] { new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"), new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"), new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e"), new Guid("9835cf5d-0b43-463e-b8f7-3bc94b911679"), new Guid("38ec7f61-aa60-4ed1-8b08-41783423e1e8"), new Guid("70736cc9-1194-44ac-a5e5-fb4b7f165b09"), new Guid("c5d92ded-e42f-439f-a559-63d353b73223") };

        public TestDataGeneratorController(IMongoDatabase database)
        {
            _database = database;
        }

        [HttpGet("all")]
        public void CreateAll()
        {
            CreateNationalSociety();
            CreateUsers();
            CreateHealthRisks();
            CreateProjects();
            CreateProjectsHealthRisks();
        }

        [HttpGet("projectshealthrisks")]
        public void CreateProjectsHealthRisks()
        {
            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(System.IO.File.ReadAllText("./TestData/HealthRisks.json"));
            var projects = JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));
            
            foreach (var project in projects)
            {
                List<Guid> healthRiskIds = new List<Guid>();
                Random randomizer = new Random();
                for (int i=0; i<5; i++)
                {
                    var availableRisks = risks.Where(v => !healthRiskIds.Contains(v.Id));
                    var risk = availableRisks.Skip(randomizer.Next(availableRisks.Count())).First();
                    Apply(Guid.NewGuid(), new ProjectHealthRiskThresholdUpdate()
                    {
                        ProjectId = project.Id,
                        HealthRiskId = risk.Id,
                        Threshold = risk.Threshold ?? 1
                    });
                }
            }
        }

        [HttpGet("projects")]
        public void CreateProjects()
        {
            var _collection = _database.GetCollection<Project>("Project");
            _collection.DeleteMany(v => true);

            var projects = JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));
            foreach (var project in projects)
                Apply(project.Id, project);
        }

        [HttpGet("nationalsocieties")]
        public void CreateNationalSociety()
        {
            var _collection = _database.GetCollection<NationalSociety>("NationalSociety");
            _collection.DeleteMany(v => true);

            var societies = JsonConvert.DeserializeObject<NationalSocietyCreated[]>(System.IO.File.ReadAllText("./TestData/NationalSocieties.json"));
			foreach (var society in societies)
				Apply(society.Id, society);
        }

        [HttpGet("users")]
        public void CreateUsers()
        {
            var _collection = _database.GetCollection<User>("Users");
            _collection.DeleteMany(v => true);

            var societies = JsonConvert.DeserializeObject<NationalSocietyCreated[]>(System.IO.File.ReadAllText("./TestData/NationalSocieties.json"));
            var users = JsonConvert.DeserializeObject<UserCreated[]>(System.IO.File.ReadAllText("./TestData/Names.json"));
            int i = 0;

            foreach (var user in users)
            {
                // Make sure we have a valid National Society ID
                if (!societies.Any(v=>v.Id == user.NationalSocietyId))
                    user.NationalSocietyId = societies[i++ % societies.Length].Id;

                Apply(user.Id, user);
            }
        }

        [HttpGet("createhealthrisks")]
        public void CreateHealthRisks()
        {
            var _collection = _database.GetCollection<NationalSociety>("HealthRisk");
            _collection.DeleteMany(v => true);

            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(System.IO.File.ReadAllText("./TestData/HealthRisks.json"));
            foreach (var risk in risks)
                Apply(risk.Id, risk);
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
                        Threshold = int.Parse(threshold),
                        ConfirmedCase = values[Array.IndexOf(columnNames, "Confirmed Case")],
                        ProbableCase = values[Array.IndexOf(columnNames, "Probable case")],
                        SuspectedCase = values[Array.IndexOf(columnNames, "Suspected Case")],
                        CommunityCase = values[Array.IndexOf(columnNames, "Community Case")],
                        Note = values[Array.IndexOf(columnNames, "Note")],
                        KeyMessage = values[Array.IndexOf(columnNames, "Key Message")]
                    };
                }
            );
        }

        [HttpGet("createprojectsjson")]
        public void CreateProjecstJson()
        {
            List<ProjectCreated> list = new List<ProjectCreated>();

            var client = new System.Net.WebClient();
            var jsonString = client.DownloadString("https://api.rss2json.com/v1/api.json?rss_url=https%3A%2F%2Freliefweb.int%2Fupdates%2Frss.xml%3Fsource%3D1242%26theme%3D4591.4604.4602");
            var items = JsonConvert.DeserializeObject<JToken>(jsonString).SelectToken("items");
            int i = 0;
            Random r = new Random();
            foreach (var item in items)
            {

                var title = item.SelectToken("title").ToString();
                title = title.Split(':').Select(v => v.Trim()).Last();

                list.Add(new ProjectCreated()
                {
                    Id = Guid.NewGuid(),
                    Name = title,
                    NationalSocietyId = _nationalSocietyIds[i % _nationalSocietyIds.Length],
                    DataOwnerId = _userIds[i % _userIds.Length],
                    SurveillanceContext = (ProjectSurveillanceContext)(r.Next(0, Enum.GetValues(typeof(ProjectSurveillanceContext)).Length - 1))
                });

                i++;
            }

            System.IO.File.WriteAllText("./TestData/Projects.json", JsonConvert.SerializeObject(list.ToArray()));
        }

        private void ConvertSeparatedFileWithHeadersToJson<T>(string inputFilePath, string outputFilePath, string separator, Func<string[], string[], T> callback)
        {
            var lines = System.IO.File.ReadAllLines(inputFilePath);
            string[] columnNames = lines.First().Split(separator);
            var list = new List<T>();
            foreach (string line in lines.Skip(1))
            {
                string[] values = line.Split(separator);
                list.Add(callback(columnNames, values));
            }
            System.IO.File.WriteAllText(outputFilePath, JsonConvert.SerializeObject(list.ToArray()));
        }
    }
}
