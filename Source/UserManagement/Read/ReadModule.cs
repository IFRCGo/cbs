
using Read.DataCollectors;
using Read.GreetingGenerators;
using Read.StaffUsers.Models;

namespace Read
{
    public static class ReadModule
    { // TODO: This is temporary, we want to automatically discover BsonClassMaps in startup.

        public static void RegisterReadModelClassMaps()
        {
            new DataCollectorClassMap();
            new GreetingHistoryClassMap();
            new BaseUserClassMap();
        }
    }
}