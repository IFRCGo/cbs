using Concepts.AlertRules;
using Concepts.DataOwners;
using Dolittle.ReadModels;

namespace Read.DataOwners
{
    public class DataOwner : IReadModel
    {
        public DataOwnerId Id { get; set; }
        public Email Email { get; set; }
        public NameOfDataOwner Name { get; set; }

    }
}
