/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Domain.TextMessages
{
    public class MultipleCaseReportContent : CaseReportContent
    {
        public int HealthRiskId { get; set; }
        public int FemalesUnder5 { get; set; }
        public int FemalesOver5 { get; set; }
        public int MalesUnder5 { get; set; }
        public int MalesOver5 { get; set; }
    }
}