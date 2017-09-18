---
title: 
description: 
keywords: 
author: 
---
# Runtime Exceptions

The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

Exceptions MUST NOT ever be used to control program flow. Exceptions are always to be considered as
an *exceptional* program state. Getting an exception should mean that the system typically can't
recover.

## Avoiding exceptional states

To avoid getting into the need to deal or throw exceptions and it ending up being a means to
control program flow, you should do the necessary checks and in fact govern the program flow from
making decisions ahead of time rather than when an *exceptional state* has occurred.

## Infrastructure

Most of the time exceptions should be considered to be related to underlying infrastructure.
We need to be able to communicate infrastructural problems. At times it is possible to recover
from even infrastructural problems; typically in the cloud where resources might be transiently
failing. Having retry policies is the thing that will help you recover.
