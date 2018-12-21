/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
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

        public void Handle(CreateHealthRiskTestData cmd)
        {
            var risks = JsonConvert.DeserializeObject<CreateHealthRisk[]>(
                System.IO.File.ReadAllText("../Domain/Tests/Data/HealthRisks.json"));

            foreach (var risk in risks)
            {
                var root = _healthRiskAggregate.Get(risk.Id);
                root.CreateHealthRisk(risk.Name, risk.CaseDefinition, risk.Number);
            }
        }

        public void Handle(CreateNationalSocietyTestData cmd)
        {
            var societies =
                JsonConvert.DeserializeObject<CreateNationalSociety[]>(
                    System.IO.File.ReadAllText("../Domain/Tests/Data/NationalSocieties.json"));

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
        //        TODO EventHor(events, e => e.HealthRiskId);
        //    }
        //}

        //public void Handle(CreateProjectTestData cmd)
        //{
        //    var projects =
        //        JsonConvert.DeserializeObject<ProjectCreated[]>(System.IO.File.ReadAllText("./Data/Projects.json"));

        //    TODO EventHor(projects, e => e.Id);
        //}

        public void Handle(CreateUserTestData cmd)
        {
            var societies =
                JsonConvert.DeserializeObject<CreateNationalSociety[]>(
                    System.IO.File.ReadAllText("../Domain/Tests/Data/NationalSocieties.json"));

            var users = JsonConvert.DeserializeObject<CreateUser[]>(
                System.IO.File.ReadAllText("../Domain/Tests/Data/Users.json"));
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