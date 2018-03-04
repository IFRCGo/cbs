using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Concepts;

namespace Domain.Specs.StaffUser.Registering
{
    public class constants
    {
        public static readonly IEnumerable<Guid> valid_assigned_to_national_societies 
                                    = new ReadOnlyCollection<Guid>(new List<Guid>{ Guid.NewGuid(), Guid.NewGuid() });

        public static readonly Location valid_location = new Location(45,45);
        public const string valid_position = "position";
    }
}