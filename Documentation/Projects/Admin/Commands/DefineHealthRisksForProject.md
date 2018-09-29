---
title: 
description: 
keywords: 
author: roarfred
---
# Command: DefineHealthRiskForProject

## Abstract
> After a project is created, it is up to the [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level) to define which healt risks should be monitored. There is a global list of all defined health risks, from which each project can choose exactly five. In this global list, there are attributes such as an ID, a name for the risk, causes and a threshold which should be used to trigger alerts in the system. Even if these attributes are defined already for each risk, any project can choose to override the Name and the Threshold. (there is also a value indicating for a window of time when the threshold value is not to be exceeded, we'll need a name and a reference for this)

## Description
This command is used to define which health risks are monitored for a project, if names are to be customized and/or along with 
thresholds and window of time for the threshold. There are exactly 5 health risks chosen from a list. For each one, the following
information is to be provided:

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
HealthRisk | The associated health risk, picked from a predefined list | Combo | [x]
Name | Defaults to the name from the predefines list, but can be changed | Free text | [x]
Threshold | The number of incidents that are required in order to raise an alert | Numeric (integer) | [x]
TimeWindow | The number of days that the threshold must be exceeded within for the alert to be raised | Numeric (integer) | [x] 

## Actors
* [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level)

## Affected data
* [Project](../ReadModels/Project.md)

## Events raised
* [Project Health Risks Set](../Events/ProjectHealthRisksSet.md)