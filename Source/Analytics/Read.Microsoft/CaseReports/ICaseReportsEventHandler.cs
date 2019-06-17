namespace Read.CaseReports
{
    public interface ICaseReportsEventHandler
    {
        void Handle(CaseReport @event);
    }
}