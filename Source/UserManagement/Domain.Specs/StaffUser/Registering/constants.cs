using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Domain.Specs.StaffUser.Registering
{
    public class constants
    {
        public static readonly IEnumerable<Guid> valid_assigned_to_national_societies 
                                    = new ReadOnlyCollection<Guid>(new List<Guid>{ Guid.NewGuid(), Guid.NewGuid() });
    }
}