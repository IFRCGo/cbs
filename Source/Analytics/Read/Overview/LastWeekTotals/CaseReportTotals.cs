/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Concepts;
using Dolittle.ReadModels;
using System;

namespace Read.Overview.LastWeekTotals
{
    public class CaseReportTotals : IReadModel
    {
        public Day Id { get; set; }
        public NumberOfPeople Female { get; set; }
        public NumberOfPeople Male { get; set; }
        public NumberOfPeople Over5 { get; set; }
        public NumberOfPeople Under5 { get; set; }
    }
}
