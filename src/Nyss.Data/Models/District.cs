namespace Nyss.Data.Models
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Region Region { get; set; }
    }
}
