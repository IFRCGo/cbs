---
title: 
description: 
keywords: 
author: karolikl
---
# Event: CaseReportReceived

## Structure
```javascript
{
        public DateTimeOffset Timestamp { get; set; }
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    "Timestamp"                         // Timestamp of when the report was received
    "CaseReportId": "000...0000",       // Guid, global identifier of the case report
    "DataCollectorId": "00...000",      // A pointer to the global identifier of the data collector who submitted the report
    "HealthRiskId",                     // A pointer to the global identifier of the health risk reported
    "Sex",                              // Sex of the health risk subject. 1 = Male, 2 = Female
    "Age",                              // Age of the health risk subject.
    "Longitude",                        // Longitude from which the case report was sent
    "Latitude",                         // Latitude from which the case report was sent
}
```

## Raised by
* Raised when [Receiving a text message](../Processes/ReceivingTextMessage.md) with a valid format from a known data collector.