using System.IO;
using System.Reflection;
using Dolittle.Commands.Handling;
using Dolittle.Domain;
using Dolittle.Serialization.Json;
using Domain.Management.HealthRisks.TestData.Data;

namespace Domain.Management.HealthRisks.TestData
{
    public class TestDataCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<HealtRisk> _healthRiskAggregate;
        readonly ISerializer _serializer;

        public TestDataCommandHandler(IAggregateRootRepositoryFor<HealtRisk> healthRiskAggregate, ISerializer serializer)
        {
            _healthRiskAggregate = healthRiskAggregate;
            _serializer = serializer;
        }

        T DeserializeTestData<T>(string path)
        {
            var assembly = typeof(TestDataCommandHandler).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + path))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var result = _serializer.FromJson<T>(json);
                    return result;
                }
            }
        }

        public void Handle(PopulateHealthRiskTestData cmd)
        {
            var healthRisks = DeserializeTestData<HealthRiskTestDataHelper[]>("Management.HealthRisks.TestData.Data.HealthRisks.json");

            foreach (var healthRisk in healthRisks)
            {
                var root = _healthRiskAggregate.Get(healthRisk.Id.Value);

                root.HealthRisk(
                    healthRisk.Id,
                    healthRisk.Name,
                    "case definition",
                    healthRisk.ReadableId
                );
            }
        }
    }
}
