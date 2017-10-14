---
title: 
description: 
keywords: 
author: roarfred
---
# Command: CreateProject

## Abstract
> Whenever *someone* determines there is need for action, a [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level) will create a new CBS project. The process of creating the project is rather simple, but getting it started might take quite some effort. As such, the project is first created in a *draft* state, such as several actors can perform their individual actions. When enough data is collected and provided into the system, the project will be published.

## Description
This command is used for the step of defining a project in the draft state. It must be done by a 
[CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level), who provides the following information:

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
Name | A name of project | Free text | [x]
NationalSociety | The national Society responsible for the project, e.g. Kenya Red Cross | From list of all national Red Cross and Red Cresent movement sosieties | [x]
DataOwner | The [Coordinator](../../actors.md#coordinator--supervisor) of the project after the initial setup | List of eligible users inside chosen National Society | [x] 

## Actors
* [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level)

## Affected data
* [Project](../ReadModels/Project.md)

## Events raised
* [Project Created](../Events/ProjectCreated.md)