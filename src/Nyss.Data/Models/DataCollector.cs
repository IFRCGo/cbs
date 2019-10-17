using NetTopologySuite.Geometries;
using Nyss.Data.Concepts;

namespace Nyss.Data.Models
{
    public class DataCollector
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DataCollectorType DataCollectorType { get; set; }

        public string DisplayName { get; set; }

        public string PhoneNumber { get; set; }

        public string AdditionalPhoneNumber { get; set; }

        public Point Location { get; set; }

        public virtual SupervisorUser Supervisor { get; set; }

        public virtual Project Project { get; set; }

        public virtual Village Village { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
