---
title: 
description: 
keywords: 
author: karolikl
---
# Event: CaseReportFromUnknownDataCollectorReceived

## Structure
```javascript
{
    "Timestamp"                         // Timestamp of when the report was received
    "CaseReportId": "000...0000",       // Guid, global identifier of the case report
    "Origin",                           // The origin of the report (eg. the phone number of the sender)
    "HealthRiskId",                     // A pointer to the global identifier of the health risk reported
    "Sex",                              // Sex of the health risk subject. 1 = Male, 2 = Female
    "Age",                              // Age of the health risk subject.
    "Longitude",                        // Longitude from which the case report was sent
    "Latitude",                         // Latitude from which the case report was sent
}
```

## Raised by
* Raised when [receiving a text message](../Processes/ReceivingTextMessage.md) with a valid format from an unknown data collector.