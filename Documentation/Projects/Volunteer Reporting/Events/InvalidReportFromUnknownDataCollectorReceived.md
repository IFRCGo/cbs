---
title: 
description: 
keywords: 
author: karolikl
---
# Event: InvalidReportFromUnknownDataCollectorReceived

## Structure
```javascript
{
    "CaseReportId": "000...0000",       // Guid, global identifier of the case report
    "Origin",                           // The origin of the report (eg. the phone number of the sender)
    "Message",                          // The content of the report
    "ErrorMessages",                    // The error messages from the invalid parsing of the report
    "Timestamp"                         // Timestamp for when the report was received
}
```
## Raised by
* Raised when [receiving a text message](../Processes/ReceivingTextMessage.md) with an invalid format from an unknown data collector.