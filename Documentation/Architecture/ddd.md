---
title: Domain Driven Design
description: A high level overview of Domain Driven Design
keywords: Domain Driven Design
author: fredrkl 
---
# Overview

Eric Evans wrote in 2004 the book [Domain Driven Design - Tackling Complexity in the Heart of Software](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215/ref=sr_1_1?ie=UTF8&qid=1506262190&sr=8-1&keywords=domain+driven+design). Here he introduces a set of tools and idees on how to keep complex domain logic under control in software. The end goal is to be able to represent the domain in software as close to the way domain experts keep it in their heads. We should be able to read out code and have the domain experts correct us.

Vaughn Vernon followed up in 2013 with the book [Implementing Domain Driven Design](https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon/dp/0321834577/ref=sr_1_4?s=books&ie=UTF8&qid=1506262653&sr=1-4&keywords=domain+driven+design). Here he goes into depth on how to take the tools and ideas and implement them.

For a quick introduction to DDD, you should read [this](https://www.amazon.com/Domain-Driven-Design-Distilled-Vaughn-Vernon/dp/0134434420/ref=pd_sim_14_2?_encoding=UTF8&pd_rd_i=0134434420&pd_rd_r=45FW5DFQNS81CFCYJ981&pd_rd_w=mHc0j&pd_rd_wg=14tZB&psc=1&refRID=45FW5DFQNS81CFCYJ981)

## Implementation

There are many ways to implement an expressive domain model that encapsulate the domain logic. Regardless on how you choose to implement it, there are some principles to follow. Keep the domain model in the center. Developers often has a tendency to focus to much on persistence. A domain model is NOT the same as a database schema. How you choose to persist data is secondary to the domain model.

## Context Map

Keep a Context Map that clearly depict the different [bounded context](./bounded_contexts.md) and there relationships. Each bounded context have there own ubiquitous language.
For an in depth explanation of context map see Eric Evans Book og Vaughn Vernon's. But basically it shows how changes in one context affect another.

### Upstream dependency

If your bounded context have a upstream dependency on another it means that if it changes then our context need to incorporate that change. We take the upstream dependencies terms and use them.

### Downstream dependency

The opposite of upstream. We dictate change and the other contexts must incorporate those.

### Anti-corruption layer

This is when we are in a upstream dependency but we are not willing to take in their terms and and concepts. We create a layer that maps them into our Ubiquitous Language.

### Partnership

When we find us in a relationship with a second team where we share codebase for example, then this could be a sensible relationship. The teams meet up and synchronize.

## Ubiquitous Language

This is basically a list of terms used in a given bounded context with a precise definition as possible. The Ubiquitous Language should then be used throughout the solution.