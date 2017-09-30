using MongoDB.Driver;

namespace Read.Disease
{
    public class Diseases : Repository<Disease>, IDiseases
    {
        public Diseases(IMongoDatabase database) : base(database, "Disease")
        {
        }
    }
}
