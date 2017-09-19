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

### Method

```csharp
public class Shopping
{
    public void AddProductToCart(Guid product, int quantity)
    {
        // Code to handle the command...
    }
}
```

### Object

An object representing the command would look like below:

```csharp
public class AddProductToCart
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