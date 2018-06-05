using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Read.MongoDb
{
    public class NoBsonClassMapRegistered : ArgumentException
    {
        public NoBsonClassMapRegistered(string message) : base(message) { }
    }
}
