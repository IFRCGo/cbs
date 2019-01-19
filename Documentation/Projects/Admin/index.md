---
title: 
description: 
keywords: 
author: einari,roarfred
---
# Admin
Admin's main interests lies within
* System configuration - national societies, projects, health risks defaults
* Operational status
* Cross national societies analytics
* User management

## Noteworthy issues
* Global to local settings https://github.com/IFRCGo/cbs/issues/936


## Scenarios

![areas of interests](assets/scenarios.png)
* Create national society<br/>
The creation of national society is currently a manual task performed by DoLittle as automated provisioning is not ready. 

* Operational status
Is the system running, are we getting reports, are we sending alerts?

* Reporting aggregate numbers
Used to promote CBS, keep track of evolution. 

* Health risk management

* Project management 
A project is defined of time, place and health risks. 
Data owners must be able to create and maintain projects. 


## System context
![Image of system context](assets/system-context.png)

* Reporting<br>
Admin is a stake holder in reporting regarding language of data collector registration and defintion of feedback messages. 
![feedback interest](assets/reporting-feedback.png)

* Alerts<br>
Admin's interest in reporting lies with configuring default settings for alert rules

* Analytics
Admin needs access to analytics, some reports must be cross national societies. Se physical 
    

## Physical infrastructure - 

Each national society exists as a tenant in the system. A tenant has its own datastore. Users are routed to a tenant by the DoLittle sentry by examining URL.

![physical infrastructure](assets/physical-view.png)
