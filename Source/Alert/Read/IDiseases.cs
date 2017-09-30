using System;

namespace Read
{
    public interface IDiseases
    {
        Disease GetById(Guid id);
        void Save(Disease entity);
    }
}