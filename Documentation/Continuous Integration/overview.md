---
title: Overview of continuous integration
description: 
keywords: CI
author: sheeng
---
# Overview

## Setup Ci Build with Bounding Context

1. Copy the `appveyor.yml` file from (Build/appveyor.yml) into the root source folder for the bounding context.
1. Change the `<BaseSourceFolder>` part under the `only_commits` section to the root source folder for the bounding context.
1. Change the two variable under the section `environment` with the relative path to the `bin` folder of the `web project` relative from `Build\build.cake`. the relative path to the solution file of the new bounding context relative from `Build\build.cake`.

Setup Appveyor services for folks with access to CBS's official accounts:

1. Create a new Project on `https://ci.appveyor.com`.
1. Add the path to the newly created yml file in the field `Custom configuration .yml file name` under the `General` tab.

Setup Appveyor services for developer folks:

1. Create the entry for the new bonding context in the `Build status` table on to of this page.

### Build Using Docker Container

* Build image: `./dockerize.sh`
* Run container: `./containerize.sh`
* Build example (inside container): `./build.sh`

After running `./dockerize.sh` script, you have a `<image-owner>/cbs-devel` image for building the project.
Folks with access to CBS's official accounts can publish the Docker images to Docker Hub.
Please remember to update the CI/CD pipeline to reflect the official Docker images.

Use `./containerize.sh` to access the terminal inside the container, created from `<image-owner>/cbs-devel` image.

On the terminal inside the container, use `./build.sh` to build the project.

## AppVeyor

AppVeyor is our primary build platform. This is the build that generates deployables and governs [versioning](../Deployment/versioning.mg).
Even though our project only has one repository, we utilize AppVeyors [filtering](https://www.appveyor.com/docs/how-to/filtering-commits/)
capability to only build those projects that are changed for the different projects.

## TravisCI / CircleCI

Our TravisCI/CircleCI builds used to validate on other platforms such as Linux, which is the runtime environment.

Folks with access to CBS's official accounts can now add CI/CD builds to CircleCI/TravisCI.

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