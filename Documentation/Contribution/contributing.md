---
title: About contributing
description: Detailed description about how to get started contributing
keywords: Contributing
author: einari
---
# Contributor Guide

Join the world’s largest humanitarian organisation and code for good!

We welcome contributions to this project whether they are bug fixes, new features or documentation. To ensure we build CBS according to the needs and wishes of the product owners at the Red Cross and to ensure the application created will be sustainable, we kindly ask you to adhere to the guidelines below as closely as possible.  

## Interpretation
The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

## Code of Conduct

You MUST familiarize yourself with our [Code of Conduct](CODE_OF_CONDUCT.md).

## Architecture

You MUST familiarize yourself with the intended [architecture](../Architecture/index.md) of this project. Any changes not adhering to the architecture will be rejected in code reviews.

## Code

- (For backend) Normal .NET coding guidelines apply. 
- (For frontend) The [Angular style guidelines](https://angular.io/guide/styleguide) apply.
- Adhere to the [editor settings](./editor.md) defined.
- All code files MUST contain a [Copyright header](./copyright_header.md).
- Exceptions MUST NOT ever be used to control program flow, as described in [Runtime Exceptions](./runtime_exceptions.md).

## Process

1. Find an issue you want to work on. Issues labeled "UpforGrabs" are issues that should be relatively easy to get started on without too much background information.   
[![GitHub issues UpForGrabs](https://img.shields.io/github/issues/ifrcgo/cbs/upforgrabs.svg)](https://github.com/IFRCGo/cbs/labels/UpForGrabs)
1. Create a fork. In order to contribute to this project, you will need to [fork](https://help.github.com/articles/fork-a-repo/) this repository.
1. Make changes, test them and ensure the documentation is up to date. All commits SHOULD be related to an [issue](./issues.md) by adding a #{number of issue} to the comment.
1. Synchronize your fork. Keep your fork synchronized with the CBS repository to avoid conflicts, as described [here](https://help.github.com/articles/syncing-a-fork/).
1. Create a pull request. Once your changes are ready, create a [pull request](https://help.github.com/articles/creating-a-pull-request/) and reference the issues you have worked on.

## Getting started

Are you ready to save lives? Go to the [getting started](./getting_started.md) section for more information.
