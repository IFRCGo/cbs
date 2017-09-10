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

## Travis

Our Travis builds are to validate on other platforms such as Linux, which is the runtime environment.

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