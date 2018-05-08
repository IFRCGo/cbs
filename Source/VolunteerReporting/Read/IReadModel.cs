using System;
using Dolittle.ReadModels;

namespace Read
{
    public interface IReadModel<TId> : IReadModel
        where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}