namespace Nyss.Data.Models
{
    public class UserNationalSociety
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int NationalSocietyId { get; set; }
        public virtual NationalSociety NationalSociety { get; set; }
    }
}
