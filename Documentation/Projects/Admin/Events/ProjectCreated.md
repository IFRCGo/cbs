---
title: 
description: 
keywords: 
author: roarfred
---
# Event: ProjectCreated

## Structure
```javascript
{
    "Id": "000...0000",                 // Guid, global identifier of the project 
    "Name": "My project",               // A name describing the project
    "NationalSocietyId": "00...000",    // A pointer to the global identifier of a national society
    "OwnerUserId",                      // A pointer to the global identifier of a CBS user, registered as the data owner
    "HealthRisks": [                    // Array of five elements describing the health risks to me monitored
        {...},
        {...},
        {...},
        {...},
        {...}                                        
    ],
    "Locations": [                      // The geographical, hierarchial structure of admin levels and data verifiers
        "Name": "Kenya",
        "GeographicalArea": { ... },
        "Locations" : [
            "Name": "Region1",
            (...)
        ]
    ]
}
```

## Raised by
* [Create Project](../Commands/CreateProject.md)