using System;

namespace Read
{
    public interface IHaveReadModelIdOf<TId>
        where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}