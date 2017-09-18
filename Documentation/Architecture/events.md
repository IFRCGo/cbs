---
title: About Events
description: A detailed description about events
keywords: event
author: einari
---
# Events

Unlike representing the user intention through a [command](./commands.md) or similar, an event
represents the actual state change in the system - the thing that happpened. Its name should be
past-tense, reflecting that it has happened.

By capturing things in events we get new opportunities in representing the actual truth to what is
happening in a system. Take for instance an e-commerce and the following scenario:

* User adds Product A to the cart
* User adds Product B to the cart
* User removes Product A from the cart

If we only have the current state of the cart as the truth in our system, we will only know that
there is a cart with Product B in it - rather than the valuable insight of the user removing something
from the cart. For instance we could present alternatives to the user, we could harvest the information
and gain insight into our users behaviors or insight into our own business - maybe some products are
avoided for a particular reason when users navigate around and find other things.

## Event Store & data

One of the benefits one get with having events is the ability to have a perfect audit trail.
This is referred to as the event store. Instead of having a typical database as the source of truth
in the system, the event store becomes that and the database is considered transient.
This gives us a lot of flexibility in how we represent data. Since the resulting data is not the actual
source of truth, we can allow ourselves to have duplicates - with different representations optimized
for different needs. A good example could be search indexes. While some databases support things like
full text search across a database, its not the best fit for a search - we could then put things into
an index when things change. We would also be able to actual know when to invalidate a cache, rather
than rely on complex solutions to keep track of changes.

## Eventual consistency

In distributed computing, technical transactional integrity is hard or close to impossible if you are to
maintain performance. By ensuring the integrity of the [command](./commands.md) we can then guarantee that
when the event is published and stored in the event store that it has happened. The rest of the system
will then have to be eventual consistent and deal with its own state as fast as possible.
For a system, this is usually fine. There are however scenarios where you need to guarantee that you
can read a certain state immediately after it has happened - also known as ACID.
For this particular project, we are fine with eventual consistency for now and will be dealing with
it when needed - until then there will be no guidance. (When there is guidance, this will be updated).

## Idempotency

## Processing

Every event that gets published needs to be processed.

```csharp
public class CartEventProcessors
{

    public void Process(ItemAddedToCart @event)
    {

    }
}
```

## Versioning, Migration

## Examples

```csharp
public class ItemAddedToCart
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public decimal GrossPrice { get; set; }
    public decimal NetPrice { get; set; }
    public int Quantity { get; set; }
}
```

```csharp
public class ItemRemovedFromCart
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
}
```

```csharp
public class QuantityChanged
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
```

Notice that unlike the [command](./commands.md), we have more details on the event. For instance, the price.