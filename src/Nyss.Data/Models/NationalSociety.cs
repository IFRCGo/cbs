using System.Collections.Generic;

namespace Nyss.Data.Models
{
    public class NationalSociety
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsArchived { get; set; }

        public string RegionCustomName { get; set; }

        public string DistrictCustomName { get; set; }

        public string VillageCustomName { get; set; }

        public string ZoneCustomName { get; set; }

        public virtual ContentLanguage ContentLanguage { get; set; }

        public virtual ICollection<UserNationalSociety> NationalSocietyUsers { get; set; }
    }
}
