/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.CaseReport;
using Read.DataCollectors;
using Read.HealthRisks;

namespace Read.CaseReportsForListing
{
    public interface ICaseReportsForListing : IExtendedReadModelRepositoryFor<CaseReportForListing>
    {
        IEnumerable<CaseReportForListing> GetAll();

        void SaveInvalidReportFromUnknownDataCollector(CaseReportId caseReportId, string message, string origin, 
            IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveInvalidReport(CaseReportId caseReportId, DataCollector dataCollector, string message, string origin, 
            double latitude, double longitude, IEnumerable<string> errorMessages, DateTimeOffset timestamp);

        void SaveCaseReportFromUnknownDataCollector(CaseReportId caseReportId, HealthRisk healthRisk, string message, string origin, 
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);

        void SaveCaseReport(CaseReportId caseReportId, DataCollector dataCollector, HealthRisk healthRisk, string message, string origin,
            int numberOfMalesUnder5, int numberOfMalesAged5AndOlder, 
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, DateTimeOffset timestamp);
    }
}