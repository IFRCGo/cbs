---
title: Offline synchronization
description: A proposed solution to the problem of data entry with uncertain Internet Connectivity
keywords: Offline
author: hemm1
---

# Offline synchronization

In order to actually be able to register data in the field without Internet connectivity (offline), and this data to be automatically synced when device is online, we propose the following solution:

We create native mobile/tablet applications wrapping the web pages we are currently creating. Instead of posting data directly to backend using HTTP, the web views will instead post action objects/events to a local database in the applications. This will allow the users to keep adding data as though they are online, and not really care about the connectivity of their device.

In addition, the application includes a background service task/worker which periodically checks Internet connectivity and fetches the events from the app database and posts these to the backend using HTTP. It also updates the local application database with the "sync status" of each event as it is sent to the backend. That way, it will also be possible for the app user to ensure that everything is synced (and even manually start syncing) if she wants to.

Notes:
* The frontend applications we are creating will need to have good input validation in order to be as sure as possible that the data posting will be successful whenever Internet connectivity is regained.
* Sequentiality in posting the events to the backend can be upheld if needed using either timestamps or increasing ID's when saving events.


![Offline syncing overview](./images/offline_syncing.png)
