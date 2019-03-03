using Concepts.SMS.Gateways;
using Dolittle.Tenancy;

namespace Core.GatewayEndpoints
{
    public interface ITenantMapper
    {
        TenantId GetTenantFor(ApiKey apiKey);
        void SetTenantFor(ApiKey apiKey, TenantId tenantId);
    }
}