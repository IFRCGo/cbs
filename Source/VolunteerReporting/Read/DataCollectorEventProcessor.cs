 using Events.External;
 
 namespace Read
{
 public class DataCollectorEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public void Process(DataCollectorRegistered @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.Id);
            if (dataCollector == null){
                dataCollector = new DataCollector{
                    Id = @event.Id
                };
                _dataCollectors.Create(dataCollector);
                }
            else {
                //TODO: Update volunteer properties
                _dataCollectors.Update(dataCollector);
                }
        }
    }
}