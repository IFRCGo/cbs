namespace Infrastructure.AspNet.ConnectionStrings
{
    public class ConnectionString
    {
        public ConnectionStringType Type { get; set; }
        public string Value { get; set; }
        public string Database { get; set; }
    }
}