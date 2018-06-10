using System;

namespace Infrastructure.Read.MongoDb
{
    public class NoBsonClassMapRegistered : Exception
    {
        public NoBsonClassMapRegistered(string message) : base(message) { }
    }
}
