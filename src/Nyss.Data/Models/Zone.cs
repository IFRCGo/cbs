namespace Nyss.Data.Models
{
    public class Zone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Village Village { get; set; }
    }
}
