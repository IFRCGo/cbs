using System;
using System.Collections.Generic;
using System.Text;

namespace Rules
{
        public interface IRuleImplementationFor<TDelegate>
        {
            TDelegate Rule { get; }
        }
}
