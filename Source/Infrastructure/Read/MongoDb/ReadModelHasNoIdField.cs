using System;

namespace Infrastructure.Read.MongoDb
{
    public class ReadModelHasNoIdField : ArgumentException
    {
        public ReadModelHasNoIdField()
        { }
        public ReadModelHasNoIdField(string message) : base(message) { }
        public ReadModelHasNoIdField(string message, Exception innerException) : base(message, innerException) { }

        public ReadModelHasNoIdField(string message, string paramName, Exception innerException) : base(message, paramName, innerException) { }
    }
}