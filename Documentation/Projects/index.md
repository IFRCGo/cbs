---
title: About projects
description: This contains an overview of the different projects
keywords: Projects, Bounded Contexts
author: einari
---
# Projects

The projects are organized according to the [bounded context](../Architecture/bounded_contexts.md) they belong to.
Within the `Source` folder you'll find the different projects and its equivalent bounded context:

| Name | Description | Issues |
| ---- | ----------- | ------ |
| [Admin](./Admin/index.md) | Web-based interface for Global coordinator to create new CBS project (per country). Based on "role", add/adapt/remove ALERTS, assign "role", add/update/remove user. | [link](https://github.com/IFRCGo/cbs/projects/1?) |
| [Visualization](./Visualization/index.md) | Web-based visualization of SMS-reports, access/information varies based on user "role" (defined in VOLUNTEER MANAGEMENT).  | [link](https://github.com/IFRCGo/cbs/projects/5?) |
| [Alerts](./Alerts/index.md) | Logic/structure behind SMS escalation such as Volunteer SMS receipt notifications/escalation, when to notify Coordinator for field validation (e.g. IF "disease"='cholera' AND "cases">10 AND "days"<7 AND "location"='PaP'), and manual SMS escalation to Ministry of Health by Coordinator.  | [link](https://github.com/IFRCGo/cbs/projects/6?) |
| [Volunteer Engagement](./Volunteer%20Engagement/index.md) | To improve chances of sustained activity and motivation, the system must interact with the volunteers through ad-hoc and regular feedback such as ad hoc one-way push notifications (e.g. outbreak spread to new area), web-based one-on-one SMS conversation (e.g. follow-up on no reporting), and structured/timed one-way reports ("Thank you for submitting # of CBS report this week.  # reports have been submitted in you "location"."). | [link](https://github.com/IFRCGo/cbs/projects/3?) |
| [User Management](./User%20Management/index.md) | Spreadsheet/database of CBS team (Volunteer, Coordinator, MOH, Global) demographic information including method for collection (SMS or web-based), entry/exit points, and linked to VOLUNTEER REPORTING and ALERTS spreadsheets/databases. | [link](https://github.com/IFRCGo/cbs/projects/2?) |
| [SMS Reports](./SMS%20Reports/index.md)  | Spreadsheet/database of SMS reports, including API entry/exit points, and  linked to ALERTS.  | [link](https://github.com/IFRCGo/cbs/projects/4?) |

| [Portal](./Portal/index.md) | | |

