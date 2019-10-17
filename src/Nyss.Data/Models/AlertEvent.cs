using System;

namespace Nyss.Data.Models
{
    public class AlertEvent
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Alert Alert { get; set; }
        public virtual User User { get; set; }
    }
}
