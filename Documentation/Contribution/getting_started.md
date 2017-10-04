---
title: Getting started
description: How to get started as a contributor to the project
keywords: 
author: karolikl
---
# Getting Started

In order for you to get started easily, we have created an overview of the tools needed and how you can get the application up and running. 

If you haven't already familiarized yourself with the [Contributor Guide](./contributing.md), please do so before proceeding. 

_Eager to get started right away? Have a look at the [example application](../../Source/Example/readme.md). to see how each project is structured._

## Setting up your development environment

Make sure you have the required [development tools](./development_tools.md) installed. 

## Understanding the project structure

CBS has been divided into 5 [bounded contexts](../Architecture/bounded_contexts.md) (or projects). Each bounded context is isolated from the others, and the communication between them is event-driven. This means that the bounded context you are working in will process incoming [events](../Architecture/events.md) from other bounded contexts and emit events for other bounded contexts to process. 

### Source code
Each bounded context has its own subfolder in the [Source](https://github.com/IFRCGo/cbs/tree/master/Source) folder. Everything you need to build and run the application within a bounded context can be found within the specified folder for that bounded context. 
For example: Everything you need to build and run the "Volunteer Reporting" bounded context, can be found in the [Volunteer Reporting](https://github.com/IFRCGo/cbs/tree/master/Source/VolunteerReporting) folder under Source. 

### Documentation and backlog
In addition to this, each bounded context has its own documentation and its own backlog. The documentation can be found in the [Documentation/Projects](https://github.com/IFRCGo/cbs/tree/master/Documentation/Projects) folder while the backlog can be found on the [GitHub project page](https://github.com/IFRCGo/cbs/projects).
For example: The documentation for the "Volunteer Reporting" bounded context can be found in the [Volunteer Reporting](../Projects/Volunteer Reporting/index.md) folder. The backlog can be found on the "Volunteer Reporting" [project page](https://github.com/IFRCGo/cbs/projects/4). 

## Build

You can build either locally or using a Docker container. 

### Build Using Docker Container

* Build image: `./dockerize.sh`
* Run container: `./containerize.sh`
* Build example (inside container): `./build.sh`

See [Overview](../Continuous Integration/overview.md) of Continuous Integration for more information.

