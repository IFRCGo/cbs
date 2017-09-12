---
title: About inversion of control
description: A detailed description about what inversion of control is
keywords: 
author: einari
---
# Inversion of Control

In our solutions we have units of code, these units - typically types such as classes - should only have one responsibility.
This means they will most likely be dependent on other units doing work for them, or they might just be part of some other
larger orchestration. The dependencies are not something the unit governs itself, we inverse the control and you specify
your dependencies going into the unit, typically a constructor:

An example of this could be:

```csharp
public class CartController
{
    ICart _cartForCurrentUser;

    public CartController(ICart cart)
    {
        _cart = cartForCurrentUser;
    }
}
```

The cart could be something like below.

```csharp
public interface ICart
{
    Guid Id { get; }
    IEnumerable<CartLine> Lines { get; }
}
```

Notice that we are taking a dependency on the actual cart, not a repository for working with the cart.
It could've been a repository as well - but to prove a point, we're going to use the cart directly.
Since something else will give us the cart implementation and governs its lifecycle we don't have to
make any decisions on how the cart gets created, is it a persisted cart, is it a per Web session cart
or anything like that. Our cart controller can just assume that there will be a cart and something else
will provide it for us. Chances are at the very minimum that the cart is per user, but all of this is
goverened outside the system that just needs it.

This is a responsibility the `CartController` should not have and we then get to focus on what is important
for it, rather than have to deal with the lifecycle. In fact, as you'll see with IoC containers - we could
have it govern this in various ways.

## Dependency Inversion

## IoC Container

## Dependencies / Interfaces

There is nothing saying a dependency has to be represented as interfaces, in fact they can be anything,
any type. I'd probably stay away from primitive types such as `string`, `int` or similar - as you'd need
to create very specific bindings in the container for the type with the dependencies.

### Testing purposes

A benefit one gets from doing it this way is that you can much more easily create isolated unit tests without
having to worry about testing more than the unit. Most tests you write would then test the interaction between
the systems. This however would require you to be able to replace the concrete code with predictable code
that gives the same result every time you run the test. This is often referred to as faking, stubbing or mocking.
It is about not providing the real implementation, but a temporary mock of the implementation that we have full
control over. Needless to say, you would then need to have your dependencies represented with types that allow
you to do this, such as an interface, a class with virtual methods on it - or even an abstract class.
Delegates are also fine for this, as we can give lambdas directly from our test setup code.

### Concrete types - virtual methods / abstract classes     


## Conventions