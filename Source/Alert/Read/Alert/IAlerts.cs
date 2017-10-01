using System;

namespace Read.Alert
{
    public interface IAlerts
    {
        Alert GetById(Guid id);
        void Save(Alert alert);
    }
}