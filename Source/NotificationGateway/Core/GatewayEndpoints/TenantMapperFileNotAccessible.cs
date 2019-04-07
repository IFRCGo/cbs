using System;
using System.IO;

namespace Core.GatewayEndpoints
{
    public class TenantMapperFileNotAccessible : IOException
    {
        public TenantMapperFileNotAccessible(string message) : base(message)
        {
        }

        public TenantMapperFileNotAccessible(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}