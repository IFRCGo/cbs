---
title: About Commands
description: A detailed description about commands
keywords: command
author: einari
---
# Commands

A command is the concept representing the users intent. It is the thing the system
will have authorization around, input validation and business rules.
Its technical representation can be in the form of a method in the system with its
parameters being the attributes of the command. But it could also be modelled as an
object with a name and its attributes.

## Actors

Commands are performed by users of the system, these are referred to as actors.
Read more about the actors defined in this system [here](../Projects/actors.md).

## Transactions

A command is also the domain specific transactional boundary. The things one need to
commit together should be on the command, or the parameters of the method.

## Examples

Below are a few examples.

### Controller Action

An approach to representing a command would be to have it as a controller action.
This would represent something that is very familiar to developers coming from
an API perspective.

```csharp
[Route("/api/Shopping/[controller])]
public class CartController : Controller
{
    [HttpPut("{product}")]
    public void AddProductToCart(Guid product, [FromBody]int quantity)
    {
        // Code to handle the command...
    }
}
```

### Separate Object with handler

The same command could be encapsulated as an object and having a handler that handles it.
This would require you to secure the object and validate the properties on the object,
which would cause you to have to implement infrastructure to deal with this.

```csharp
public class AddItemToCart
{
    public Guid Product { get; set; }
    public int Quantity { get; set; }
}
```

For handling the command you'd have a system as follows:

```csharp
public class ShoppingCommandHandlers
{
    public void Handle(AddProductToCart command)
    {
        // Code to handle the command...
    }
}
```