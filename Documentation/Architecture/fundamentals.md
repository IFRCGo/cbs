---
title: Fundamentals
description: A walkthrough of important fundamentals
keywords: Fundamentals
author: einari
---
# Fundamentals

With the particular architecture chosen for this project, there are some things that might be
fundamentally different. This document describes the things you should be thinking about when
designing your features.

## Primary Keys

In traditional database designs, the primary key has often been governed by the datasource itself.
This works fine when the database is the source of truth. In an [event driven](./event_driven.md) system
and the [event store](./event_store.md) holds the truth but is not partitioned on a domain concept,
or traditional tables. This means that you need to work differently with unique identifiers.
The identifier can either a [natural key](https://en.wikipedia.org/wiki/Natural_key) that is naturally unique
and part [the ubiquitous language](ddd.md) in your [bounded context](bounded_contexts.md).
Another approach would be to use a [Guid](https://msdn.microsoft.com/en-us/library/system.guid(v=vs.110).aspx).
Common for both is that you must be able to know this already on the client side - there is no datasource
that will generate this for you.

## Read Models

The consequence of an [event](./events.md) can be a piece of data or a snapshot of the consequence if you like
used for primarily reading purposes. With the [event store](./event_store.md) at the core and representing
the actual source of truth, we can allow ourselves to have multiple representations - optimized for the needs
we have in the different features. We often end up being [polyglot persistent](https://en.wikipedia.org/wiki/Polyglot_persistence),
even within a feature. Good example of this would be for a catalog in an e-commerce solution where the catalog itself
sits in a database of some sort while for searching for products you'd have a search index that gets updated
every time someone added something got added or removed to/from the catalog from an event.
