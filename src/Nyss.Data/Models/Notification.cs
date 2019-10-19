using System;
using Nyss.Data.Concepts;

namespace Nyss.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public bool IsOpened { get; set; }

        public NotificationType NotificationType { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
