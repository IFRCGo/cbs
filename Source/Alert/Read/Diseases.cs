using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class Diseases : Repository<Disease>, IDiseases
    {
        public Diseases(IMongoCollection<Disease> collection) : base(collection)
        {
        }
    }
}
