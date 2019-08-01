/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Concepts;
using Dolittle.ReadModels;

namespace Read.Overview.LastWeekTotals
{
    public class CaseReportTotals : IReadModel
    {
        public Day Id { get; set; }
        public NumberOfPeople FemalesUnder5 { get; set; }
        public NumberOfPeople MalesUnder5 { get; set; }
        public NumberOfPeople FemalesOver5 { get; set; }
        public NumberOfPeople MalesOver5 { get; set; }
    }
}
