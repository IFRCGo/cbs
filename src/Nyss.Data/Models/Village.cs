namespace Nyss.Data.Models
{
    public class Village
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual District District { get; set; }
    }
}
