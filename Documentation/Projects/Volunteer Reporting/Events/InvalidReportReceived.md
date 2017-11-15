---
title: 
description: 
keywords: 
author: karolikl
---
# Event: InvalidReportReceived

## Structure
```javascript
{
    "CaseReportId": "000...0000",       // Guid, global identifier of the case report
    "DataCollectorId": "00...000",      // A pointer to the global identifier of the data collector who submitted the report
    "Message",                          // The content of the report
    "ErrorMessages",                    // The error messages from the invalid parsing of the report
    "Timestamp"                         // Timestamp for when the report was received
}
```

## Raised by
* Raised when [receiving a text message](../Processes/ReceivingTextMessage.md) with an invalid format.