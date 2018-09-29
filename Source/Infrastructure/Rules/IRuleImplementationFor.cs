/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2018 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Rules
{

    public interface IRuleImplementationFor<TDelegate>
    {
        TDelegate Rule { get; }
    }
}
