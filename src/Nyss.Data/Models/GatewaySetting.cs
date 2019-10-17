using Nyss.Data.Concepts;

namespace Nyss.Data.Models
{
    public class GatewaySetting
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ApiKey { get; set; }

        public GatewayType GatewayType { get; set; }

        public virtual NationalSociety NationalSociety { get; set; }
    }
}
