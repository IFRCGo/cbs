---
title: 
description: 
keywords: 
author: 
---
# Event Store

The purpose of an event store is to save all events that happen in a system.
An event store is [immutable](./glossary.md) and considered append only.
This means if you put something into the event store that is wrong, you must
put in place a compensating event that rectifies the situation.

Alongside the actual content of the event sits metadata about when the event occured,
which user or system was responsible for the event to have happened, its origin and more.

[Events](./events.md) are different from any other type of entities you typically would store.