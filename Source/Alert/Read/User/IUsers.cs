using System;

namespace Read
{
    public interface IUsers
    {
        User GetById(Guid id);
        void Save(User user);
    }
}