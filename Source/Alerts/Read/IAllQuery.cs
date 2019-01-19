using System.Linq;
using Dolittle.ReadModels;

namespace Read
{
    public interface IAllQuery<T> where T : IReadModel
    {
        IQueryable<T> Query { get; }
    }
}
