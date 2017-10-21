---
title: About Events
description: A detailed description about events
keywords: event
author: einari
---
# Events

The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

Events represents the actual state change happening in a system. Rather than just saving the state,
you represent the change with an event. It is not technical in nature - but represents the domain
language - the [ubiquitous language](https://en.wikipedia.org/wiki/Domain-driven_design) in your domain.

By capturing things with events we get new opportunities in representing the actual truth to what is
happening in a system. Take for instance an e-commerce and the following scenario:

* User adds Product A to the cart
* User adds Product B to the cart
* User removes Product A from the cart

If we only have the current state of the cart as the truth in our system, we will only know that
there is a cart with Product B in it - rather than the valuable insight of the user removing something
from the cart. For instance we could present alternatives to the user, we could harvest the information
and gain insight into our users behaviors or insight into our own business - maybe some products are
avoided for a particular reason when users navigate around and find other things.

This forms a perfect audit trail when we save this permanently in an [event store](./event_store.md).

## Naming

Events represents the past tense; what has happened to the system. Unlike [commands](./commands.md) that
represents pre tense; what the user wants to have happen. Commands can fail due to authorization, validation
or other business reasons - while events can't fail. They are considered the truth of the system and in
fact the single source of truth in an [event store](./event_store.md) system. Naming MUST therefor be
in past tense. Naming is by far one the more challenging parts - it needs to capture the state change
with the domain terminology. Don't take the modelling of this lightly, if you're not 100% sure you **MUST**
seek out the domain expert to get this right. Read more on rules of engagement through our [contribution guidelines](../Contribution/contributing.md).

## EventStorming

Capturing events in a system can be demanding, a technique called [EventStorming](http://ziobrando.blogspot.no/2013/11/introducing-event-storming.html)
can be used. It is a very effective way to get the domain experts involved and surface the actual state
changes in a timeline of a system or parts of a system.

## Difference from a command

For one [command](./commands.md) entering a system, there is not necessarily a one to one relation with
the object modelled for the command and the event. Take the cart example of adding something to a cart.
Often you might find that to be the case you **MUST NOT** shortcut this by saying its the same object
or even introduce inheritance to save time. A command and an event serves two completely different purposes
and should not be modelled together; command in a Domain project, while the event in an Events project.
Read more about the [DRY principle](./dry.md) for when to optimize repetition and when to not.

The command would look like below:

```csharp
public class AddItemToCart
{
    public Guid Product { get; set; }
    public int Quantity { get; set; }
}
```

The event coming out would be different. We would pull the price for instance and augment this on the
backend.

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

## Representing with multiple events

As mentioned, there is no correlation between commands and events. When handling the command, this could
then result in multiple events. If you look at dealing with [versioning](#versioning), you'll see that
over time you might add new meaning to the system and this is introduced naturally with new events.
One **SHOULD** try to capture new insight into the domain explicitly with new events rather than implicitly
adding in a property and losing the meaning.

## Complexity

Events should be kept very simple and represent the actual state change that happened to the system.
You typically model state changes as the things that needs to be changed together.

## Primitive Types

When dealing with events that gets stored in an immutable [event store](./event_store.md), you have to
be more careful what you store. You **MUST** only save primitive types on an event. The reason for this
is to reduce complexity for versioning of the event. If you bring in complex objects, complexity in versioning
can easily go up exponentially. Primitive types include the following:

* Integers (e.g. byte, sbyte, int, uint, short, long, Int32, Int64)
* Float / Double / Decimal - keep in mind that precision might be lost during serialization - example: [JSON](https://tools.ietf.org/html/rfc7159.html#section-6)
* String
* bool
* char

In addition to this, there are some more complex structured value types that are allowed and considered stabile:

* DateTime / DateTimeOffset (Recommended to use DateTimeOffset as it holds more correct timezone information)
* Guid

### Flatten it out

Events **SHOULD NOT** be complex structures in themselves, but kept simple and flattened out.
When capturing real state changes, you should not need complex structures. This is just an additional
precision on using [primitive types](#Primitive Types).

## Idempotency

In mathematics you find the concept of [idempotence](https://en.wikipedia.org/wiki/Idempotence);
you should be able to apply operations multiple times without it changing the result. In an event based
system with an [event store](./event_store.md) you'll find this concept mentioned as well.
With an [event store](./event_store.md) you enable the possibility to replay events. You do this
for instance if you want to get rid of all your read models, for instance if you're changing storage mechanism.
To be able to get to the same result, you must have enough information on your events that the
[event processors](./event_processor.md) make use of. This means that your event processor should not
be looking up data somewhere else to get to the result. Looking something up to be able to produce the
result creates a dependency making it impossible to guarantee the result.

This does not mean that you should be keeping full entities on the event - still follow the rule of
[complexity](#Complexity) as mentioned and remember to model the actual state change.
Be aware of this and model accordingly.

Important to keep in mind that the snapshot of a state is a series of events, these together form
the snapshot. This should reduce what you keep on them but as a whole they help guarantee the result
when a replay would occur.

In addition to events being modelled correctly and the processor doing it right, ordering is an important
aspect of dealing with events. The underlying system guarantees ordering of events when replaying and also
that your [event processor](./event_processor.md) can assume that events are being delivered once and once only.
This is built into the underlying system being used. You as a developer do not have to worry about this.

Simple rules of thumb:

1. Keep enough information on an event so that an event processor don't need to do a look up
1. You **SHOULD** keep complexity down - don't put full entities on the event. The sequence of events is eventually the state.
1. Events are delivered to your event processors in order
1. Events are delivered once and once only
1. If replayed, typically manually - the system overrides the once and once only rule. This is an edge-case

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

## Processing

Every event that gets published needs to be processed. This is done by dropping a class into for instance
the Read project. You **MUST NOT** put one into the Domain project, as this is dealing with other aspects.

```csharp
public class CartEventProcessors : IEventProcessor
{
    public void Process(ItemAddedToCart @event)
    {

    }
}
```

### Processing once

For some things you don't want to have the processor be called more than once, even when replaying.
Good examples of this is when you're sending out communication through email, sms, push notifications or similar.
Even though you replay events for a particular reason, you don't want to resend all the communication.

```csharp
public class CampaignProcessors  : IEventProcessor
{
    public void ProcessOnce(CampaignInformationSent @event)
    {

    }
}
```

> [!Note]
> This is not introduced yet - you **SHOULD** therefor not use this, as it would never be called right now.

## Versioning

In an event based system that stores events in an [event store](./event_store.md) and your system is divided into
[bounded contexts](./bounded_contexts.md) and deployed on different release cadences, backwards and forward compatibility
is something you need to keep in mind. This means that you should not introduce breaking changes into an event,
because there might be a consumer of it that won't understand the breaking change. You should then consider introducing
a new event - enabling you in your bounded context to introduce new functionality without having to break
others.

When one discovers new meaning or changes in the domain you **MUST** follow the following guidelines:

1. Is this new meaning, new functionality typically -> Introduce a new event type to capture the it
1. Is this an additional piece of state that naturally fits with existing event -> Add a new property to event
1. Is this changing the meaning of an existing event -> Implement an event migrator

> [!Note]
> **When adding new properties**
> Put in a default value for the new property. During replay of old events, they will match the properties found, but not
> the new property. If there is no natural default value and this is in fact completely required, it means there is new meaning.

> [!Note]
> **On event migrators**
> More details will come on how to do migrations

## Event Examples

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