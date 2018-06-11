using System;
using Concepts;
using Dolittle.Commands;

namespace Domain.DataCollector.Changing
{
    public class ChangeBaseInformation : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        //TODO: Add later on. public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}
