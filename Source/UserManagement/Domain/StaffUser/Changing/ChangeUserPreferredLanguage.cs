using System;
using System.Collections.Generic;
using System.Text;
using Concepts;
using Dolittle.Commands;

namespace Domain.StaffUser.Changing
{
    public class ChangeUserPreferredLanguage : ICommand
    {
        public Guid StaffUserId { get; set; }
        public Language PreferredLanguage { get; set; }

        public Role Role { get; set; }
    }
}
