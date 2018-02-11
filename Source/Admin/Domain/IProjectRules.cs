/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Domain
{
    public interface IProjectRules
    {
        bool IsProjectNameUnique(string name);
        bool IsUserNotAVerifier(Guid projectId, Guid userId);
    }
}