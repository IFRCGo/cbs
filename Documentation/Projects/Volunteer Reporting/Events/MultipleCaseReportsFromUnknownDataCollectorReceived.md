---
title: 
description: 
keywords: 
author: karolikl
---
# Event: MultipleCaseReportsFromUnknownDataCollectorReceived

## Structure
```javascript
{
    "Timestamp"                         // Timestamp of when the report was received
    "CaseReportId": "000...0000",       // Guid, global identifier of the case report
    "Origin",                           // The origin of the report (eg. the phone number of the sender)
    "HealthRiskId",                     // A pointer to the global identifier of the health risk reported
    "NumberOfMalesUnder5",              // Number of observations for males under the age of 5
    "NumberOfMalesOver5",               // Number of observations for males over the age of 5
    "NumberOfFemalesUnder5",            // Number of observations for females under the age of 5
    "NumberOfFemalesOver5",             // Number of observations for females over the age of 5
    "Longitude",                        // Longitude from which the case report was sent
    "Latitude",                         // Latitude from which the case report was sent
}
```

## Raised by
* Raised when [receiving a text message](../Processes/ReceivingTextMessage.md) with a valid format, containing multiple observations for a health risk, from an unknown data collector.