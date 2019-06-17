namespace Read.DataCollectors
{
    public interface IDataCollectorsEventHandler
    {
        void Handle(DataCollector dataCollector);
    }
}
