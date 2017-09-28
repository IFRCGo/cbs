using System;

namespace Infrastructure.AspNet.ConnectionStrings
{
    public class MissingConnectionStringForDatabaseType : ArgumentException
    {
        public MissingConnectionStringForDatabaseType(ConnectionStringType type) : base($"ConnectionString for database type '{type}' is missing")
        {

        }
        
    }
}