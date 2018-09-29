using System;

namespace Infrastructure.Read.MongoDb
{
    public class CustomBsonClassMapRegistratorNotProvided : Exception
    {
        public CustomBsonClassMapRegistratorNotProvided(string message) : base(message) { }
    }
}