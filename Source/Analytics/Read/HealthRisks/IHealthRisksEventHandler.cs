namespace Read.HealthRisks
{
    public interface IHealthRisksEventHandler
    {
        void Handle(HealthRisk healthRisk);
    }
}