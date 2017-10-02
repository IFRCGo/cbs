---
title: Overview of continuous integration
description: 
keywords: CI
author: einari
---
# Overview

## AppVeyor

AppVeyor is our primary build platform. This is the build that generates deployables and governs [versioning](../Deployment/versioning.mg).
Even though our project only has one repository, we utilize AppVeyors [filtering](https://www.appveyor.com/docs/how-to/filtering-commits/)
capability to only build those projects that are changed for the different projects.

### Configuring a build for your project in AppVeyor

1. Copy the `appveyor.yml` file from (Build/appveyor.yml) into the root source folder for the bounding context.
1. Change the `<BaseSourceFolder>` part under the `only_commits` section to the root source folder for the bounding context.
1. Change the two variable under the section `environment` with the relative path to the `bin` folder of the `web project` relative from `Build\build.cake`. the relative path to the solution file of the new bounding context relative from `Build\build.cake`. 

The folowing steps has to be done by a person with access to to CBS`s appveyor account.
1. Create a new Project on `https://ci.appveyor.com`.
1. Add the path to the newly created yml file in the field `Custom configuration .yml file name` under the `General` tab

Done by a developer
1. Create the entry for the new bonding context in the `Build status` table on to of this page.

#### Build Using Docker Container

* Build image: `./dockerize.sh`
* Run container: `./containerize.sh`
* Build example (inside container): `./build.sh`

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