/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Domain.TextMessages
{
    public class InvalidCaseReportContent : CaseReportContent
    {
        public string ErrorMessage { get; set; } = "Text message should contain 3 or 5 numbers, separated by hashes (#). Ex: 1#3#5 or 1#3#0#4#4";
    }
}