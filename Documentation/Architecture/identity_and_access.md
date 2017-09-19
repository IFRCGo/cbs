---
title: Identity and access
description: How the identity and access works
keywords: Authentication, Authorization
author: einari
---
# Identity and Access

Making sure only users and systems that should have access are authenticated and have the correct authorization is
considered its own [bounded context](bounded_contexts.md). We will rely on third party software based on open standards
for dealing with this.

## Actors

As part of the project, there are certain [actors](../Projects/actors.md) that have been defined. These are the same as the
roles they play and is what governs authorization. You will find this as part of the token and concretely the application
role claim.

## Standards

### OAUTH2 + OpenID

### JWT Tokens

## Azure Active Directory

### B2C

### Single Sign On

## Identity Server

As part of development, there is need to be able to have an end to end scenario without having access to all that is in the cloud.
Identity Server plays an important role in this and you'll find the source for it [here](../../Source/IdentityServer).
It is also packaged into a Docker image and put [here](http://www.vg.no).
