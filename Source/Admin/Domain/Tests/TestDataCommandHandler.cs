/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.IO;
using System.Linq;
using System.Reflection;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Domain.HealthRisks;
using Domain.NationalSocieties;
using Domain.Users;
using Newtonsoft.Json;

namespace Domain.Tests
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        private readonly IAggregateRootRepositoryFor<HealthRisk> _healthRiskAggregate;
        private readonly IAggregateRootRepositoryFor<NationalSociety> _nationalSocietyAggregate;
        private readonly IAggregateRootRepositoryFor<User> _userAggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<HealthRisk> healthRiskAggregate, IAggregateRootRepositoryFor<NationalSociety> nationalSocietyAggregate, IAggregateRootRepositoryFor<User> userAggregate)
        {
            _healthRiskAggregate = healthRiskAggregate;
            _nationalSocietyAggregate = nationalSocietyAggregate;
            _userAggregate = userAggregate;
        }
        
        T DeserializeTestData<T>(string path)
        {
            var assembly = typeof(TestDataCommandHandler).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name+"."+path))
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var result = new JsonSerializer().Deserialize<T>(reader);
                return result;
            }
        }
        
        public void Handle(CreateHealthRiskTestData cmd)
        {
            var risks = DeserializeTestData<CreateHealthRisk[]>("Tests.Data.HealthRisks.json");

            foreach (var risk in risks)
            {
                var root = _healthRiskAggregate.Get(risk.Id);
                root.CreateHealthRisk(risk.Name, risk.CaseDefinition, risk.Number);
            }
        }

        public void Handle(CreateNationalSocietyTestData cmd)
        {
            var societies = DeserializeTestData<CreateNationalSociety[]>("Tests.Data.NationalSocieties.json");

            foreach (var society in societies)
            {
                var root = _nationalSocietyAggregate.Get(society.Id.Value);
                root.CreateNationalSociety(society.Name.Value, society.Country, society.TimezoneOffsetFromUtcInMinutes);
            }
        }

        //public void Handle(CreateProjectsHealthRiskTestData cmd)
        //{
        //    var risks = JsonConvert.DeserializeObject<HealthRiskCreated[]>(
        //        System.IO.File.ReadAllText("./Data/HealthRisks.json"));
        //    var projects =
        //        JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./TestData/Projects.json"));

        //    foreach (var project in projects)
        //    {
        //        var healthRiskIds = new List<Guid>();
        //        var randomizer = new Random();

        //        var events = new List<ProjectHealthRiskAdded>();
        //        for (var i = 0; i < 5; i++)
        //        {
        //            var availableRisks = risks.Where(v => !healthRiskIds.Contains(v.Id));
        //            var risk = availableRisks.Skip(randomizer.Next(availableRisks.Count())).First();
        //            events.Add(new ProjectHealthRiskAdded(project.Id, risk.Id, 0));
        //        }
        // TODO: Generate test data for projects with healthriskadded
        //    }
        //}

        public void Handle(CreateProjectTestData cmd)
        {
        //    var projects =
        //        JsonConvert.DeserializeObject<CreateProject[]>(System.IO.File.ReadAllText("../Domain/Tests/Data/Projects.json"));
        // TODO: Generate test data for projects
        }

        public void Handle(CreateUserTestData cmd)
        {
            var societies = DeserializeTestData<CreateNationalSociety[]>("Tests.Data.NationalSocieties.json");
            var users = DeserializeTestData<CreateUser[]>("Tests.Data.Users.json");

            var i = 0;

            foreach (var user in users)
            {
                // Make sure we have a valid National Society ID
                if (societies.All(v => v.Id != user.NationalSocietyId))
                    user.NationalSocietyId = societies[i++ % societies.Length].Id;

                var root = _userAggregate.Get(user.Id.Value);
                root.CreateUser(user.FullName, user.DisplayName, user.Country, user.NationalSocietyId);
            }
        }
    }
}