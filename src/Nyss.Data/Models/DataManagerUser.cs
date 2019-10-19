using System;

namespace Nyss.Data.Models
{
    public class DataManagerUser : User
    {
        public bool IsDataOwner { get; set; }

        public bool HasConsented { get; set; }

        public DateTime? ConsentedAt { get; set; }

        public virtual NationalSociety NationalSociety { get; set; }
    }
}
