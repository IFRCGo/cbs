---
title: About projects
description: This contains an overview of the different projects
keywords: Projects, Bounded Contexts
author: einari
---
# Projects

The projects are organized according to the [bounded context](../Architecture/bounded_contexts.md) they belong to. For more information on how the projects are organized with regards to source code, issues and documentation, please refer to ["Understanding the project structure."](../Contribution/getting_started.md#understanding-the-project-structure).

| Name | Description | Issues |
| ---- | ----------- | ------ |
| [Volunteer Reporting](./Volunteer%20Reporting/index.md)  | Processing all incoming case reports from data collectors in the field and allowing for communication with the data collectors through ad-hoc and regular text messages. | [link](https://github.com/IFRCGo/cbs/projects/4?) |
| [Reporting](./Reporting/index.md) | Web-based visualization of all incoming case reports. The level of detail within a report is dependent on the "role" of the user. | [link](https://github.com/IFRCGo/cbs/projects/5?) |
| [Admin](./Admin/index.md) | Web-based interface for system admins where they define the global configuration within CBS, such as alert thresholds, health events, SMS gateway to use etc. They also have the ability to create new CBS projects. | [link](https://github.com/IFRCGo/cbs/projects/1?) |
| [User Management](./User%20Management/index.md) | Web-based user management, where data collectors, data managers, data coordinators etc are associated with one or several CBS projects. | [link](https://github.com/IFRCGo/cbs/projects/2?) |
| [Alerts](./Alerts/index.md) | Case report escalation when an alert threshold is reached. Escalation in this case can mean notifying nearby data collectors of health events, notifying data managers and notifying local authorities such as the Ministry of Health. | [link](https://github.com/IFRCGo/cbs/projects/6?) |
| [Portal & Infrastructure](./Portal/index.md) | "Glue" for navigating between bounded context. | [link](https://github.com/IFRCGo/cbs/projects/3?) |