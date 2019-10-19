namespace Nyss.Data.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual NationalSociety NationalSociety { get; set; }
    }
}
