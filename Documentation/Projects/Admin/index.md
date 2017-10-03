---
title: 
description: 
keywords: 
author: einari,roarfred
---
# Admin

## Commands
* A [CBS Coordinator (global level)](../actors.md) is __[creating a project](./Commands/CreateProject.md)__
* A [Project Owner](../actors.md) is __[defining health risks for a project](./Commands/DefineHealthRisksForProject.md)__
* A [Project Owner](../actors.md) is __[defining the SMS reporting structure for a project](./Commands/SetSmsReportingStructure.md)__
* A [CBS Coordinator (global level)](../actors.md) is __[changing the data owner of a project](./Commands/ChangeProjectDataOwner.md)__
* A [Project Owner](../actors.md) is __[Setting the area structure and data verifiers for a project](./Commands/ChangeAreasAndDataVerifiers.md)__

* A [CBS Coordinator (global level)](../actors.md) is __[Adding a new global HealthRisk](./Commands/CreateHealthRisk.md)__
* A [CBS Coordinator (global level)](../actors.md) is __[Modifying an existing global HealthRisk](./Commands/ModifyHealthRisk.md)__


## Aggregates
* __[Project](./Aggregates/Project.md)__
* __[Health Risk](./Aggregates/HealthRisk.md)__

## Events
* __[A new project was created](./Events/ProjectCreated.md)__
* __[The data owner was changed](./Events/ProjectDataOwnerChanged.md)__
* __[Health Risks for project was defined](./Events/ProjectHealthRisksChanged.md)__
* __[Areas and data verifiers was changed](./Events/ProjectAreasChanged.md)__
* __[The SMS reporting structure changed](./Events/ProjectSmsReportingStructureChanged.md)__

* __[A new global Health Risk was created](./Events/HealthRiskCreated.md)__
* __[A global Health Risk was updated](./Events/HealthRiskUpdated.md)__
