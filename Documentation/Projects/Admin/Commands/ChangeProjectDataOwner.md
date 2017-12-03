---
title: 
description: 
keywords: 
author: roarfred
---
# Command: ChangeProjectOwner

## Abstract
> During a project, due to various reasons, there might be a need for reassigning the data owner of the project. On some occations, the current data owner must be released before a new if found. This can cause the project to be without a data owner for a limited time.

## Description
This command is used when [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level) wants to reassign the data owner. It will require the following information:

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
Id | The global identifier of the project | From selector or current project | [x]
DataOwner | The [Coordinator](../../actors.md#coordinator--supervisor) of the project after the initial setup | List of eligible users inside chosen National Society |

## Actors
* [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level)

## Affected data
* [Project](../ReadModels/Project.md)

## Events raised
* [ProjectDataOwnerChanged](../Events/ProjectDataOwnerChanged.md)