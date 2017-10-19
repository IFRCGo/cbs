using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RecipientType { get; set; }
        public string Geo { get; set; }
    }
}
