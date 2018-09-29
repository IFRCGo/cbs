---
title: 
description: 
keywords: 
author: roarfred
---
# Read Model: Project

## Abstract
> A CBS **Project**, which defines under whom and under which rules various health risks are being surveiled in an area. 
> There will never be more than one ongoing project per country, and the national red cross or red cresent association will be the owner,
> refered as National Society.
>
> The goal of the project is to utilize volunteers precense in rural areas, to look out for and report single observations that can be early 
> signs of outbreaks or other incidents of catastopic measure. Each volunteer is registered on a spesific (fixed) geo location, and multiple 
> reports within the same general area can be the early warning needed to start preventive measures to stop the outbreak.
>
> A project contains a geographical, hierarchial, structure, where a [data verifier]() is mapped to locations at one specific level. It 
> may vary which levels are available, and at what level the data verifier is mapped, but it will be consistent througout the project.
> The geographical structure is gathered from whatever GIS system might be available in the area, and will be imported into the project during
> the initial stage.
> 
> After a project is created, it is up to the [CBS coordinator (global level)](../../actors.md#cbs-coordinator---global-level) 
> to define which healt risks should be monitored. There is a global list of all defined health risks, from which each project
> can choose exactly five. In this global list, there are attributes such as an ID, a name for the risk, causes and a threshold
> which should be used to trigger alerts in the system. Even if these attributes are defined already for each risk, any project 
> can choose to override the Name and the Threshold. (there is also a value indicating for a window of time when the threshold 
> value is not to be exceeded, we'll need a name and a reference for this)

## Data Structure
* Project
  * Health Risks
  * Locations


## Health Risks
> A Health Risk is a contagious disease, or other health related problem with a potential of causing an outbreak. People in the
> area becomes in immediate need for healthcare, which is possibly scarce or not available

A global list of defined healt risks exists. From this, 5 is selected for the project. The health risk in the global list will have
suggestions on cases and thresholds, but these attributes might be overridden within the project. There will however be a reference 
back to the list for reporting purposes.

## Locations
> The term **Locations** is a breakdown structure of the area within a country. There are a fixed number of admin levels, 7. The 
> first level (Admin Level 0) is always the country. Depending on the size of the country and it's maturity within GIS, there might be  
> just a few levels available. One single location in the structure is a name and a geospatial area. This area will have a relation 
> to a parent location on the level above it, unless the area represents the whole country. The geospatial area might be unavailable
> while the name and the parent location is known.

Locations are fully defined within the bounds of the project. During the initial stage of the project, GIS data is imported into the
project. As administrative boundaries might change, this setup can vary for two successive projects within the same country.

The project owner determines at which admin level a Data Validator is to be assigned and then assigns one data validator to each 
location on that level.