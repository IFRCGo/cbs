namespace Nyss.Data.Models
{
    public class AlertRecipient
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }
        
        public virtual AlertRule AlertRule { get; set; }
    }
}
