namespace Read.Alerts
{
    public interface IAlertEventHandler
    {
        void Handle(Alert @event);
    }
}