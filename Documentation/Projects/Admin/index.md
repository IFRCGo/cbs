---
title: 
description: 
keywords: 
author: einari,roarfred
---
# Admin

## Processes

### [Defining a project](./Processes/DefiningProject.md)

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

### [Defining Health Risks](./Processes/DefiningHealthRisks.md)

> A Health Risk is a contagious disease, or other health related problem with a potential of causing an outbreak. 
> People in the area could be in immediate need for healthcare, which is possibly scarce or not available


