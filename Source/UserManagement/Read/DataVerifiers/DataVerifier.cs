using Concepts.DataVerifier;
using Dolittle.ReadModels;

namespace Read.DataVerifiers
{
    public class DataVerifier : IReadModel
    {
        public DataVerifierId Id { get; set; }
        public string FullName { get; set; }
    }
}
