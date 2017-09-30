using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class Diseases : Repository<Disease>
    {
        public Diseases(IMongoCollection<Disease> collection) : base(collection)
        {
        }
    }
}
