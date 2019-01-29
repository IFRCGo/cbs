/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.CaseReports
{
    public class CaseReportId : ConceptAs<Guid>
    {
        public static readonly CaseReportId NotSet = Guid.Empty;

        public static implicit operator CaseReportId (Guid value)
        {
            return new CaseReportId { Value = value };
        }
        public static implicit operator CaseReportId(string id)
        {
            return new CaseReportId { Value = Guid.Parse(id) };
        }
    }
}