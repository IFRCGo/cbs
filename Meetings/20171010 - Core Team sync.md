# Core team technical sync, 10.10.2017

## Agenda

* What has happened after the codeathon?
    - Are we missing code/documentation from the codeathon?
    - Simplified onboarding & enhanced documentation
    - MVP
* Plans ahead: 
    - Kicking off Live Community Standups on October 18th
    - Einar’s Patterns & Practices tour in November
* Going forward.

## Notes

### Participants

[Einari](https://github.com/einari), [karolikl](https://github.com/karolikl), [anderaus](https://github.com/anderaus), [roarfred](https://github.com/roarfred), [eprom](https://github.com/eprom)

### Feedback from the codeathon

Most participants from the codeathon have submitted their feedback and the core team has gone through the results. The comments are much as expected, the technical preparations should have been further along and some feel that the required skillset is too advanced. The core team was prepared for this and is working to simplify. Other than that, the participants are very happy about the practicalities of the codeathon (venue, food, etc.) and they had a great time. 

### What has happened since the codeathon

In the two weeks after the codeathon, there were 54 commits by 7 contributors (of which 4 are core team members). There have also been some activity on Slack and in the issues on GitHub, by others. We need to make sure the motivation is kept high and work hard to prevent "loneliness" among the contributors. 

We do believe are missing code from the SMS gateway and the Alert team, karolikl will follow up and ensure a pull request is submitted. 

A lot of focus after the codeathon has been on simplifying the "Getting started" documentation and the contributors guide. We have introduced a ["good first issue"](https://github.com/IFRCGo/cbs/labels/good%20first%20issue) label to issues, intended for new contributors who don't have any experience with the solution and its purpose. karolikl has 3 developers "on hold" who will receive a "good first issue" each, and try to get the application up and running (without further information than the documentation in the repository). This will be the test on whether we are ready to onboard new contributors. 

The UX team has documented [UX stories](https://github.com/IFRCGo/cbs/projects/11) outlining the actors involved in the system and their requirements.  
The admin team has set the standard for documenting a project, the other teams will follow their lead.   
The build scripts have been extended to also include frontend. 

### Plans ahead

The MVP (minimum viable product) has been defined to be the Volunteer Reporting (including SMS gateway), with a simple view of the incoming text message reports. This simplifies the scope of the project and any additional functionality will be added later (alerts, admin, prjects, users etc.). The ["good first issue"](https://github.com/IFRCGo/cbs/labels/good%20first%20issue) issues will all be centered around the MVP. 

On October 18th, we will begin our bi-weekly community stand ups. They will be live-streamed on the Red Cross YouTube channel with community engagements through chat. The goal of the community standups is to enable contributors to ask the domain experts questions directly, make the contributors feel less lonely in the project and encourage new contributors to join in. 

On October 14th, Richard Campbell (host of .NETRocks podcast) will speak at Leetspeak in Stockholm. He will mention the work we are doing, and encourage developers to join in. [More information](https://leetspeak.se/2017/speakers.html#speaker-6)

In November, the Microsoft Patterns & Practices team will go on tour in Norway, Sweden, Finland and Denmark. Einar will join them, and he will spend the last 30 minutes of the day talking about this project to attract new contributors. [More information](https://www.linkedin.com/feed/update/urn:li:activity:6323502149468717056)

### Follow ups

Documentation: Concepts (einari)  
Azure subscription (einari+karolikl)  
MVP (eprom will document needs)  
Publish documentation to cbsrc.org (anderaus)  
Merging Admin & User Management (Anine, Tonje etc)    
karolikl: Test out ["good first issue"](https://github.com/IFRCGo/cbs/labels/good%20first%20issue) on 3 devs  
einari: Set up everything needed for the Live Community Standup, October 18th. Run test on the 17th?  
