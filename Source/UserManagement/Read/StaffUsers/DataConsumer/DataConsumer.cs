using System;
using Concepts;

namespace Read.StaffUsers.DataConsumer
{
    public class DataConsumer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public Location Location { get; set; }
    }
}
