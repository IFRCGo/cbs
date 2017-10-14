---
title: About Don't Repeat Yourself
description: What is DRY and when do you use it
keywords: DRY
author: einari
---
# DRY - Don't Repeat Yourself

The key words “MUST”, “MUST NOT”, “REQUIRED”, “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”,
“RECOMMENDED”, “MAY”, and “OPTIONAL” in this document are to be interpreted as described in
[RFC 2119](https://tools.ietf.org/html/rfc2119).

The DRY principle states *"Every piece of knowledge must have a single, unambiguous, authoritative representation within a system."*.
With this principle in hand one could claim that you should never repeat anything, in fact even properties.
This is somewhat problematic and often leads to coupling scenarios and rigid systems.
It is easy to get into a place where unrelated items gets dependent on each other through not repeating yourself.
With programming language features like [generics](https://msdn.microsoft.com/en-us/library/ms379564(v=vs.80).aspx) this can quite
easily escalate further and when modelling domains you can get into a place where you lose meaning in your domain.

Classic scenario of this is modelling entity models to keep things dry.
Starting off with for instance a product entity, typically used in a catalog of products:

```csharp
public class Product
{
    public string ArticleNumber { get; set; }  // The unique natural primary key
    public string Name { get; set; }
    public string Description { get; set; }

    /* ... */
}
```

Then give a cart entity where we have cart lines that would refer to the product:

```csharp
public class Cart
{
    public Guid Id { get; set; } // The unique Id for the cart - assume we persist it
    public CartLine[] Lines { get; set; }
}
```

With now two entities, one thing that often is optimized is the unique identifier part. While in product we've
called it *ArticleNumber* and *Id* in cart, we could argue they're both *Id* - they represents the global unique
identification for their entity type. We could optimize as follows:

```csharp
public class Entity<T>
{
    public T Id { get; set; }
}
```

And then have:

```csharp
public class Product : Entity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

// And

public class Cart : Entity<Guid>
{
    public CartLine[] Lines { get; set; }
}
```

We've now lost meaning in our domain, instead of keeping the *ArticleNumber* we've lost it completely and also at the
same time created a coupling between the two entities through the generic type called `Entity`.
It is **REQUIRED** that you don't do this type of optimization.

## Don't repeat the business logic

Rather than saying you should not repeat yourself for everything in a system, you **MUST NOT** repeat business logic.
Properties on a [DTO - Data Transfer Object](https://en.wikipedia.org/wiki/Data_transfer_object) is not considered logic of any kind,
they are just bearers of information. While business logic doing "... whenever X ... then Y ..." type of logic is critical to not
have scattered around repeated causing problematic maintenance issues. Modelling the [bounded context](./bounded_contexts.md) correctly
is then very important. The business logic has an owner and it should belong to a [bounded context](./bounded_contexts.md).