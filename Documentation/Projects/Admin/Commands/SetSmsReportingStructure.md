---
title: 
description: 
keywords: 
author: roarfred
---
# Command: SetSmsReportingStructure


## Abstract
> During the initial setup of the project, the [CBS coordinator (national level)](../../actors.md#cbs-coordinator---national-level) should determine and set the structure for SMS reporting from volunteers. The structure would typically be single reports when (...) and aggregated reports when (...)

## Description
This command is used when [CBS coordinator (national level)](../../actors.md#cbs-coordinator---national-level) wants to set the structure for SMS reporting from volunteers. It will require the following information:

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
Id | The global identifier of the project | From selector or current project | [x]
SmsReportingStructure | The structure to use for reporting | Choice: Single or Aggregated | 

## Actors
* [CBS coordinator (national level)](../../actors.md#cbs-coordinator---national-level)

## Affected data
* [Project](../ReadModels/Project.md)

## Events raised
* [ProjectSmsReportingStructureChanged](../Events/ProjectSmsReportingStructureChanged.md)