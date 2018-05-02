using System;
using Concepts;
using Dolittle.Commands;

namespace Domain.StaffUser.Changing
{
    public class RemoveAssignedNationalSociety : ICommand
    {
        public Guid StaffUserId { get; set; }
        public Guid NationalSociety { get; set; }

        public Role Role { get; set; }
    }
}