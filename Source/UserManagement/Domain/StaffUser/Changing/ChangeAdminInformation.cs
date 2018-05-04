using System;
using Dolittle.Commands;

namespace Domain.StaffUser.Changing
{
    public class ChangeAdminInformation : ICommand
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
