---
title: About Persistence
description: Details on what is expected from persistence
keywords: Persistence
author: einari
---
# Persistence

The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

## Integration at the database level

[bounded context](./bounded_contexts.md) MUST NOT integrate on a database level. This means
they will not be sharing a database at all. This removes friction in development and makes
it easier to build each bounded context without having to worry about the other.

## Relational vs Non Relational

Traditionally we tend to model everything relationally, while most data is not necessarily
relational in nature. There is no point in bringing the complexity of a relational database
and the need to use things like mapping to one using object relational mapping libraries,
unless the data is in fact relational.

## Polyglot

The different data storage technologies out there have different characteristics and serve
different purposes. This means that is quite ok to select a specific storage mechanism per
feature within a [bounded context](./bounded_contexts.md).
Since we have the luxury of being [event driven](./event_driven.md) and have an [event store](./event_store.md),
we can also allow duplicates in the data - meaning that we could have multiple representations
of the same data. The truth in the system comes from the event store.

## What can we use

| Type | On Premise | Cloud |
| ------------ | ---------------- | ---------------------------- |
| Documents    | MongoDB          | CosmosDB w/MongoDB interface |
| Relational   | SQL for Linux    | SQL PaaS - Azure             |
| Search Index | Elastic Search   | Azure Search (Elastic based) |
| Graph        | Neo4j w/ Gremlin | CosmosDB w/Gremlin           |
