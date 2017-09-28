---
title: About terminology used
description: A detailed description of all terminology used
keywords: Glossary, Terminology
author: einari
---
# Glossary

This describes all the terminology used throughout the project.

| Term                    | Description                                              | Resources |
| ----------------------- | -------------------------------------------------------- | --------- |
| [Command](./command.md) | Represents the users intent in pre-tense. Unlike an event, a command is not a statement of fact; it's only a request, and thus may be refused.                  |           |
| [Event](./events.md)    | Represents what happened as a state change in the system. Since an event represents something in the past, it can be considered a statement of fact and used to take decisions in other parts of the system. |           |
| Immutability            | An immutable object is an object whose state cannot be modified after it is created. Commands and events are immutable.                                                         | https://en.wikipedia.org/wiki/Immutable_object          |
| Convention over configuration | Often in software we have repeated patterns, these can often be defined as an automatic convention instead of us humans repeating them | https://en.wikipedia.org/wiki/Convention_over_configuration |
| [High cohesion](./high_cohesion.md) |                                                          |           |
| Lose coupling           |                                                          |           |
| [Inversion of Control](./inversion_of_control.md)  |                                                          |           |