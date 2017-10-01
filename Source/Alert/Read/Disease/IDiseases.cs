using System;

namespace Read.Disease
{
    public interface IDiseases
    {
        Read.Disease.Disease GetById(Guid id);
        void Save(Read.Disease.Disease entity);
    }
}