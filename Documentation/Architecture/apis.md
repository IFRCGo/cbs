---
title: About APIs
description: 
keywords: 
author: einari 
---
# APIs

The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

There are typically two classes of APIs represented; *Commands* and *Queries*.
These MAY be divided into two different files, rather than mixing them in the same files.
That would give more flexibility and one can much easier have separate security models;
controllers could require specific authorization instead of on an action level.
A lot of times you allow more users to read than write in a system.
It also helps keep focus by segregating it already on this level.

## Clients

From all the clients we will connect to the backend using APIs.

## Across application

APIs MUST never be used as a means of coupling [bounded contexts](./bounded_contexts.md) back together.
This would defy the purpose of dividing it all up. You MUST NOT expose APIs for this purpose.

## Integration

You MAY expose an API for integration purposes, this is considered a very specific and isolated feature
of the system and should be live on its own. In fact, it is its own [bounded context](./bounded_contexts.md)
and can thus be maintained completely separately.
As with other bounded contexts, it would respond to events and be autonomous and be in isolation.