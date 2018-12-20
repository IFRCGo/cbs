using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Domain.HealthRisks;
using Newtonsoft.Json;

namespace Domain.Tests
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
//    "5bba2d83-1a84-4ba1-8a1e-919e73318db6": {
//    "commands": {
//    "269f0087-f2a7-4fce-bfb6-5a136d614201": {
//    "generation": 1,
//    "type": "Domain.Tests.CreateHealthRiskTestData, Domain"
//},
//"c60d8362-ab0b-4537-8913-75212990200f": {
//"generation": 1,
//"type": "Domain.Tests.CreateNationalSocietyTestData, Domain"
//},
//"6b18da21-4a6c-4771-875f-537684c2157d": {
//"generation": 1,
//"type": "Domain.Tests.CreateProjectsHealthRiskTestData, Domain"
//},
//"5f3fb27e-08bb-4156-8323-7535bdf747e2": {
//"generation": 1,
//"type": "Domain.Tests.CreateProjectTestData, Domain"
//},
//"d344314a-8349-405c-96fb-6e39f31b42b5": {
//"generation": 1,
//"type": "Domain.Tests.CreateUserTestData, Domain"
//}
//},


        //private Guid[] _nationalSocietyIds = new Guid[]
        //{
        //    new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"),
        //    new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"),
        //    new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e")
        //};

        //private Guid[] _userIds = new Guid[]
        //{
        //    new Guid("917b98f2-1435-4b0d-88f1-f177a926e374"), new Guid("e13b1996-11a5-4d55-a04c-0cc1962cb0a9"),
        //    new Guid("267f83bf-fbe0-4fa7-a356-15fe478348b8"), new Guid("099a5bae-c8cd-472c-9a98-dc15c770598c"),
        //    new Guid("4405540c-78bc-4484-ae06-e00be468770c"), new Guid("53a5712c-663a-41f8-bbb1-bc4fd834646e"),
        //    new Guid("9835cf5d-0b43-463e-b8f7-3bc94b911679"), new Guid("38ec7f61-aa60-4ed1-8b08-41783423e1e8"),
        //    new Guid("70736cc9-1194-44ac-a5e5-fb4b7f165b09"), new Guid("c5d92ded-e42f-439f-a559-63d353b73223")
        //};

        private readonly IAggregateRootRepositoryFor<HealthRisk> _aggregate;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<HealthRisk> aggregate)
        {
            _aggregate = aggregate;
        }

        public void Handle(CreateHealthRiskTestData cmd)
        {
            var risks = JsonConvert.DeserializeObject<CreateHealthRisk[]>(
                System.IO.File.ReadAllText("../Domain/Tests/Data/HealthRisks.json"));

            foreach (var risk in risks)
            {
                var root = _aggregate.Get(risk.Id);
                root.CreateHealthRisk(risk.Name, risk.CaseDefinition, risk.Number);
            }
        }

        //public void Handle(CreateNationalSocietyTestData cmd)
        //{
        //    var societies =
        //        JsonConvert.DeserializeObject<CreateNationalSociety[]>(
        //            System.IO.File.ReadAllText("./Data/NationalSocieties.json"));

        //    TODO EventHor(societies, e => e.Id);
        //}

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

        //public void Handle(CreateUserTestData cmd)
        //{
        //    _users.Delete(_ => true);
        //    var societies =
        //        JsonConvert.DeserializeObject<NationalSocietyCreated[]>(
        //            System.IO.File.ReadAllText("./Data/NationalSocieties.json"));
        //    var users = JsonConvert.DeserializeObject<UserCreated[]>(
        //        System.IO.File.ReadAllText("./TestData/Names.json"));
        //    var i = 0;

        //    foreach (var user in users)
        //    {
        //        // Make sure we have a valid National Society ID
        //        if (!societies.Any(v => v.Id == user.NationalSocietyId))
        //            user.NationalSocietyId = societies[i++ % societies.Length].Id;

        //    }
        //    TODO No longer in use(?)
        //}
    }
}