---
title: 
description: 
keywords: 
author: roarfred
---
# Command: CreateHealthRisk

## Abstract
> The global list of health risks is a rather static list. It keeps track of which items are considered candidates for monitoring, but in any project only five is chosen to be surveiled. The list will serve as a level from where data can be aggregated across projects. Creation of new Health Risks are so to be considered somewhat rare.

## Description
This command is used when a [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level) wants to define a new Health Risk that have not before been identified.

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
Name | A name of health risk | Free text | [x]
ReadableId | A number used to identify the risk, used in SMS reports | Number (integer) | [x]
Threshold | The number of incidents needed within a time window before an alert is raised | Number (integer) |
TimeWindow | The number of days in where the threshold must be exceeded for an alert to be raised | Number (integer) |
ConfirmedCase | | Free text | 
SuspectedCase | | Free text | 
ProbableCase | | Free text | 
CommunityCase | | Free text | 
KeyMessage | | Free text | 


## Actors
* [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level)

## Affected data
* [Health Risk](../ReadModels/HealthRisk.md)

## Events raised
* [Health Risk Created](../Events/HealthRiskCreated.md)