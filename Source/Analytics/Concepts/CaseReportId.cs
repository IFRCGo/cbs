/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts
{
    /// <summary>
    /// Represents a specific date as number of days since Unix Epoch.
    /// </summary>
    public class CaseReportId : ConceptAs<Guid>
    {
        public static implicit operator CaseReportId(Guid value)
        {
            return new CaseReportId {Value = value};
        }
    }
}