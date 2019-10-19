namespace Nyss.Data.Models
{
    public class SupervisorUser : User
    {
        public string Sex { get; set; }

        public virtual NationalSociety NationalSociety { get; set; }

        public virtual Village Village { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual DataManagerUser DataManagerUser { get; set; }
    }
}
