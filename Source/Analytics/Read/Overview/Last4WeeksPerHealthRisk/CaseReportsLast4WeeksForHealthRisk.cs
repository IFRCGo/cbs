/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Concepts;
using Concepts.HealthRisks;

namespace Read.Overview.Last4WeeksPerHealthRisk
{
    public class CaseReportsLast4WeeksForHealthRisk
    {
        public HealthRiskName HealthRiskName { get; set; }
        public NumberOfPeople Days0to6 { get; set; }
        public NumberOfPeople Days7to13 { get; set; }
        public NumberOfPeople Days14to20 { get; set; }
        public NumberOfPeople Days21to27 { get; set; }
    }
}
