using System;

namespace Infrastructure.Read.MongoDb
{
    public class NoBsonClassMapRegistered : ArgumentException
    {
        public NoBsonClassMapRegistered(string message) : base(message) { }
    }
}
