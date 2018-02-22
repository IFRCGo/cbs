using System;
using System.Collections.Generic;
using System.Text;
using Concepts;

namespace Read.StaffUsers.DataConsumer
{
    class DataConsumer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public Location Area { get; set; }
    }
}
