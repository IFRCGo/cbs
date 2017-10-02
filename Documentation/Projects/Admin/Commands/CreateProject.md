---
title: 
description: 
keywords: 
author: roarfred
---
# Command: CreateProject

## Abstract
>Whenever *someone* determines there is need for action, a [CBS coordinator (global level)](../../actors.md) will create 
>a new CBS project. The process of creating the project is rather simple, but getting it started might take quite some 
>effort. As such, the project is first created in a *draft* state, such as several actors can perform their individual
>actions. When enough data is collected and provided into the system, the project will be published.

## Actors
* [CBS coordinator (global level)](../../actors.md)
* [CBS coordinator (national level)](../../actors.md)
* [Coordinator / Supervisor](../../actors.md)

## Affected data
* [Project](../Aggregates/Project.md)

## Events raised
* [Project Created](../Events/ProjectCreated.md)