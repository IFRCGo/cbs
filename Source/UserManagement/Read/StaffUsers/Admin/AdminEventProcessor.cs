using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Concepts;
using doLittle.Events.Processing;
using Events.StaffUser;

namespace Read.StaffUsers.Admin
{
    public class AdminEventProcessor : ICanProcessEvents
    {
        private readonly IAdmins _admins;

        public AdminEventProcessor(
            IAdmins admins
        )
        {
            _admins = admins;
        }

        public async Task Process(AdminAdded @event)
        {
            await _admins.SaveAsync(new Admin
            {
                DisplayName = @event.DisplayName,
                Email = @event.Email,
                FullName = @event.FullName,
                Id = @event.Id
            });
        }

        public async Task Process(StaffUserDeleted @event)
        {
            if ( (Role) @event.Role == Role.Admin)
                await _admins.RemoveAsync(@event.Id);
        }

    }
}
