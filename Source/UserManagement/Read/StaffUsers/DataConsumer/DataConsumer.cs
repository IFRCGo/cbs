using System;
using System.Collections.Generic;
using System.Text;
using Concepts;

namespace Read.StaffUsers.DataConsumer
{
    class DataConsumer
    {
        public Guid Id { get; set; }
        public String FullName { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public Location Area { get; set; }
    }
}
