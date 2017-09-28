using System.Collections.Generic;

namespace Infrastructure.AspNet.ConnectionStrings
{
    public class ConnectionStringsOptions
    {
        public ConnectionStringsOptions()
        {
            ConnectionStrings = new ConnectionString[0];
        }

        public IEnumerable<ConnectionString>   ConnectionStrings { get; set; }
    }
}