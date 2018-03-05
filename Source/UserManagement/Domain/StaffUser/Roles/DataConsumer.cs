using System;
using Concepts;

namespace Domain.StaffUser.Roles
{
    public class DataConsumer : StaffRole, IRequireLocation, ISupportSex, ISupportBirthYear, IRequireNationalSociety, IRequirePreferredLanguage
    {
        public Location Location { get; set; }

        public Sex? Sex { get; set; }

        public int? BirthYear { get; set; }

        public Guid NationalSociety { get; set; }

        public Language? PreferredLanguage { get; set; }
    }
}