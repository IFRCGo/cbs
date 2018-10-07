using Concepts;
using Concepts.DataCollectors;
using Dolittle.Commands;

namespace Domain.DataCollectors
{
    public class ChangeBaseInformation : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}
