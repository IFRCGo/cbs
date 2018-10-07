using System.Collections.Generic;

namespace Read.DataVerifiers
{
    public interface IDataVerifiers
    {
        IEnumerable<DataVerifier> GetAll();
    }
}