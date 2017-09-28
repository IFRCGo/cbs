using System.Collections.Generic;

namespace Infrastructure.AspNet.ConnectionStrings
{
    public class ConnectionStringsOptions
    {
        public ConnectionString[]   ConnectionStrings { get; set; } = new ConnectionString[0];
    }
}