/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;

namespace TextMessaging
{
    public class SingleCaseReportContent : CaseReportContent
    {
        public int HealthRiskId { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
    }
}