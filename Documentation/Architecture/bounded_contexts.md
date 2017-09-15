---
title: About bounded contexts
description: A detailed description about what bounded contexts are
keywords: Bounded Context, Domain Driven Design
author: einari
---
# Bounded Contexts

In a large system you find that the system is not a single monolithic system, but rather a composition of smaller systems.
Rather than modelling these together as one, bounded contexts play an important role in helping you separate the different
sub systems and modelling these on their own. Putting it all together in one model tends to become hard to maintain over
time and often error prone due to different requirements between the contexts that has yet to be properly defined.
We see that we often have some of the same data across a system and chose to model this only once - making the model
include more than what is needed for specific purposes. This leads to bringing in more data than is needed and becomes
a compromise. Take for instance the usage of [Object-relational mapping](https://en.wikipedia.org/wiki/Object-relational_mapping)
and a single model for the entire system approach. If you have a model with relationships and you in reality have different
requirements you end up having to do a compromise of how you fetch it. For instance, if one your features displays all
the parts of the model including its children; it makes sense to eagerly fetch all of this to save roundtrips. While if
the same model is used in a place where only the top aggregate holds the information you need, you want to be able to
lazy load it so that only the root gets loaded and not its children. The simple solution to this is to model each of the
models for the different bounded contexts and use the power of the ORM to actually map to the database for the needs one
has.

The core principal is to keep the different parts of your system apart and not take any dependency on any other contexts.

All the details about a bounded context should be available in a context map. The context map provides then a highlevel
overview of the bounded context and its artifacts.
