/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using System;
using Concepts;

namespace Read.CaseReports
{
    public class CaseReport : IReadModel
    {
        public CaseReport(CaseReportId caseReportId, Guid dataCollectorId, Guid healthRiskId,
            string origin, string message, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, double longitude,
            double latitude, DateTimeOffset timestamp)
        {
            this.Id = caseReportId;
            this.DataCollectorId = dataCollectorId;
            this.HealthRiskId = healthRiskId;
            this.Origin = origin;
            this.Message = message;
            this.NumberOfMalesUnder5 = numberOfMalesUnder5;
            this.NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            this.NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            this.NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Timestamp = timestamp;
        }
        public CaseReportId Id { get; set; }
        public Guid DataCollectorId { get;set;  }
        public Guid HealthRiskId { get; set;}
        public string Origin { get; set; }
        public string Message { get; set;}
        public int NumberOfMalesUnder5 { get;set; }
        public int NumberOfMalesAged5AndOlder { get;set; }
        public int NumberOfFemalesUnder5 { get; set;}
        public int NumberOfFemalesAged5AndOlder { get;set; }
        public double Longitude { get; set;}
        public double Latitude { get; set;}
        public DateTimeOffset Timestamp { get; set;}
    }
}
