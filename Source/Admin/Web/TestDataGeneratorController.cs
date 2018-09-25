/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Events.External;
using Events.HealthRisk;
using Events.NationalSociety;
using Events.Project;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Read.HealthRiskFeatures;
using Read.NationalSocietyFeatures;
using Read.ProjectFeatures;
using Read.UserFeatures;

namespace Web
{
    [Route("api/testdatagenerator")]
    public class TestDataGeneratorController : Controller
    {
        private readonly IHealthRisks _healthRisks;
        private readonly IUsers _users;
        private readonly INationalSocieties _nationalSocieties;
        private readonly IProjects _projects;

        private Guid[] _nationalSocietyIds = new Guid[]
        {
            new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"),
            new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"),
            new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e")
        };

        private Guid[] _userIds = new Guid[]
        {
            new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"),
            new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"),
            new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e"),
            new Guid("9835cf5d-0b43-463e-b8f7-3bc94b911679"), new Guid("38ec7f61-aa60-4ed1-8b08-41783423e1e8"),
            new Guid("70736cc9-1194-44ac-a5e5-fb4b7f165b09"), new Guid("c5d92ded-e42f-439f-a559-63d353b73223")
        };

        public TestDataGeneratorController(
            IHealthRisks healthRisks,
            IUsers users,
            INationalSocieties nationalSocieties,
            IProjects projects)
        {
            _healthRisks = healthRisks;
            _users = users;
            _nationalSocieties = nationalSocieties;
            _projects = projects;
        }

        //TODO: Integrate to DoLittle 2.0

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
            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(
                System.IO.File.ReadAllText("./TestData/HealthRisks.json"));
            var projects =
                JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));

            foreach (var project in projects)
            {
                var healthRiskIds = new List<Guid>();
                var randomizer = new Random();

                var events = new List<ProjectHealthRiskAdded>();
                for (var i = 0; i < 5; i++)
                {
                    var availableRisks = risks.Where(v => !healthRiskIds.Contains(v.Id));
                    var risk = availableRisks.Skip(randomizer.Next(availableRisks.Count())).First();
                    events.Add(new ProjectHealthRiskAdded(project.Id, risk.Id, 0));
                }
                // _eventReplayer.Replay(events, e => e.HealthRiskId);
            }
        }

        [HttpGet("projects")]
        public void CreateProjects()
        {
            _projects.Delete(_ => true);

            var projects =
                JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));
            // _eventReplayer.Replay(projects, e => e.Id);
        }

        [HttpGet("nationalsocieties")]
        public void CreateNationalSociety()
        {
            _nationalSocieties.Delete(_ => true);

            var societies =
                JsonConvert.DeserializeObject<NationalSocietyCreated[]>(
                    System.IO.File.ReadAllText("./TestData/NationalSocieties.json"));
            // _eventReplayer.Replay(societies, e => e.Id);
        }

        [HttpGet("users")]
        public void CreateUsers()
        {
            //TODO: 
            // _users.Delete(_ => true);
            // var societies =
            //     JsonConvert.DeserializeObject<NationalSocietyCreated[]>(
            //         System.IO.File.ReadAllText("./TestData/NationalSocieties.json"));
            // var users = JsonConvert.DeserializeObject<UserCreated[]>(
            //     System.IO.File.ReadAllText("./TestData/Names.json"));
            // var i = 0;

            // foreach (var user in users)
            // {
            //     // Make sure we have a valid National Society ID
            //     if (!societies.Any(v => v.Id == user.NationalSocietyId))
            //         user.NationalSocietyId = societies[i++ % societies.Length].Id;

            // }
            // _eventReplayer.Replay(users, e => e.Id);
        }

        [HttpGet("createhealthrisks")]
        public void CreateHealthRisks()
        {
            _healthRisks.Delete(_ => true);

            var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(
                System.IO.File.ReadAllText("./TestData/HealthRisks.json"));
            
            // _eventReplayer.Replay(risks, e => e.Id);
        }

        [HttpGet("createprojectsjson")]
        public void CreateProjecstJson()
        {
            var list = new List<ProjectCreated>();

            var client = new System.Net.WebClient();
            var jsonString =
                client.DownloadString(
                    "https://api.rss2json.com/v1/api.json?rss_url=https%3A%2F%2Freliefweb.int%2Fupdates%2Frss.xml%3Fsource%3D1242%26theme%3D4591.4604.4602");
            var items = JsonConvert.DeserializeObject<JToken>(jsonString).SelectToken("items");
            var i = 0;
            var r = new Random();
            foreach (var item in items)
            {
                var title = item.SelectToken("title").ToString();
                title = title.Split(':').Select(v => v.Trim()).Last();

                list.Add(new ProjectCreated(Guid.NewGuid(), title, _nationalSocietyIds[i % _nationalSocietyIds.Length], _userIds[i % _userIds.Length], 
                    r.Next(0, Enum.GetValues(typeof(ProjectSurveillanceContext)).Length - 1)));

                i++;
            }

            System.IO.File.WriteAllText("./TestData/Projects.json", JsonConvert.SerializeObject(list.ToArray()));
        }

        private void ConvertSeparatedFileWithHeadersToJson<T>(string inputFilePath, string outputFilePath,
            string separator, Func<string[], string[], T> callback)
        {
            var lines = System.IO.File.ReadAllLines(inputFilePath);
            var columnNames = lines.First().Split(separator);
            var list = new List<T>();
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(separator);
                list.Add(callback(columnNames, values));
            }

            System.IO.File.WriteAllText(outputFilePath, JsonConvert.SerializeObject(list.ToArray()));
        }
    }
}