using System;

namespace Read.Disease
{
    public class DataVerifier : Entity
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
