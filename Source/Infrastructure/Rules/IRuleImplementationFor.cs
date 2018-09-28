using System;

namespace Infrastructure.Rules
{

    public interface IRuleImplementationFor<TDelegate>
    {
        TDelegate Rule { get; }
    }
}
