---
title: About bounded contexts
description: A detailed description about what bounded contexts are
keywords: Bounded Context, Domain Driven Design
author: einari
---
# Bounded Contexts

When talking about splitting up a typical monolith into more digestible pieces, often referred to as Microservices,
its good to have a strategy about how to actually create the divide. From [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design)
we find the concept of bounded contexts. A bounded context is defined as the boundaries of a ubiquituos language.
A ubiquituos language is the language spoken and understood in for example a department. Rather than coming up with a new language to
cover all aspects, one captures only the language used.