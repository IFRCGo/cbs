---
title: Overview of continuous integration
description:
keywords: CI
author: karolikl
---
# Overview

## AppVeyor

AppVeyor is our primary build platform. This is the build that generates deployables and governs [versioning](../Deployment/versioning.mg).
Even though our project only has one repository, we utilize AppVeyors [filtering](https://www.appveyor.com/docs/how-to/filtering-commits/)
capability to only build those projects that are changed for the different projects.

### Setting up continuous integration for a project with AppVeyor

1. The Build folder contains a [template appveyor.yml](../../Build/appveyor.yml) file that is used for all projects. 
1. Each project contains an appveyor.yml file in the root folder of the project.
1. The template appveyor.yml file contains parameters in the format `<parametername>` which have to be updated according to the project in question. You should not need to update anything but the following:   
    `<TestFolder>` - The path to the folder in your project containing unit tests  
    `<SlnFile>` - The path to the projects solution file  
    `<WebBinFolder>` - The path to the bin folder of the web project  
    `<AngularFolder>` - The path to the Angular folder of the web project  
    `<baseSourceforlder>` - The path to the project folder  

### AppVeyor configuration

If you would like to set up a build towards your own fork in AppVeyor, follow the following steps: 
1. Create a new Project on `https://ci.appveyor.com` (you will need one project in AppVeyor per project build).
1. Add the path to the newly created yml file in the field `Custom configuration .yml file name` under the `General` tab. Do not edit any other settings, these are picked up from the appveyor.yml file. 

## Documentation

Part of the continuous integration is the generation of the documentation site. Built from the markdown and API changes in the common parts.

### Markdown Linting

### API Documentation

#### Events

## Tests

All automated tests runs during the continuous integration - if these fails, the build fails.

## Static Code Analysis

## Pull Requests

When a [pull request](../Contribution/pull_requests.md) comes in it triggers the build and verifies that the build is not broken the build.
This is one of the policies governing wether or not a pull request can be accepted. If the build gets broken, it is you as a contributor
who is responsible for fixing the commits leading to the broken build and amend the pull request with the fix.