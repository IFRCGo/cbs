using System;
using System.Collections.Generic;

namespace Read
{
    public interface IUsers
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        void Save(User user);
    }
}