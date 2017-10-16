---
title: 
description: 
keywords: 
author: roarfred
---
# Command: ChangeAreasAndDataVerifiers


## Abstract
> After a project is created, it is up to the [CBS coordinator (national level)](../../actors.md#cbs-coordinator---national-level) to collect and define in which areas the project will operate in, and also the granularity of theese areas. The level of detail will vary from country to country, and the data is typically gathered from a government department. Dependent on the detail levels available, the availability of healtcare facilities and the availability of volunteers, a specific level is set where data validators is to be assigned.

## Description
This command is used to import the areas and assigning data validators to areas at a specific level. The following information is to be provided: (Note that ChildAreas will represent an array of similar structure)

Field | Description | Input Type | Required
----- | ----------- | ---------- | --------
Name | The name of the area. At the top level, this will be the country | Free text | [x]
GeographicalArea | The geojson string containing a polygon for the specific area | Map control | [x]
Data Validator | Reference to a [Coordinator](../../actors.md#coordinator--supervisor) | Selector for eligible users |
ChildAreas | An array of a similar structure as this | Tree control |  

## Actors
* [CBS coordinator (national level)](../../actors.md#cbs-coordinator---national-level)

## Affected data
* [Project](../ReadModels/Project.md)

## Events raised
* [Project Areas Changed](../Events/ProjectAreasChanged.md)