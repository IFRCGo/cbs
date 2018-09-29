using System;
using Dolittle.ReadModels;

namespace Read.DataVerifiers
{
    public class DataVerifier : IReadModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
