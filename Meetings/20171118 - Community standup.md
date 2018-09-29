# Community Standup, 18.11.2017 (in person meeting)

## Agenda

* Status from the Red Cross
* Status from the volunteers
* Azure setup
* MVP / roadmap
* Next steps

### Status from the Red Cross

The Red Cross have had a busy autumn with both Tonje and Roxanne deployed to Madagasacar, where there is an ongoing plague outbreak, and with the deployment of a large field hospital in Bangladesh. Anine has conducted CBS training in Zimbabwe and worked with NorCross Africa regional office to identify the first CBSv2 project. The interest in, and the need for, CBSv2 is large both locally and globally, we aim for a field test in February/March of 2018. 

Ole, who is the innovation coordinator in the Norwegian Red Cross, will be further involved in CBSv2 going forward. 
CBS has been granted support from Innovation Norway for (among others) Codeathons, testing, field testing, which the project will benefit greatly from in the next 6 months.

### Status from the volunteers

In the past week, Einar has presented the project to over 600 developers in Sweden, Denmark, Finland and Norway. This has already given us a new contributor, and we have received interest from several more who would like to look into the project. 

*VolunteerReporting*
Most development has been done in VolunteerReporting, where we are now storing and displaying all case reports received from data collectors in a project. We have started working on the automatic feedback messages that the data collectors should receive when they submit a case report. 

*Frontend*
Alexander has created a stylesheet in the Example application. This is component-based, which means that each project can import the needed components without having to duplicate the stylesheets. 
We have a need for more frontend developers, as the team is now very backend-heavy. A couple of the backend developers are happy to provide frontend code, given that the code is reviewed by a frontend dev. 

*Access to domain experts*
Many contributors have questions for the Red Cross domain experts, and at the moment it is difficult to know where to post these questions. The Red Cross finds it difficult to follow the ongoing discussions on Slack as these discussions are often technical. We have therefore decided to create a new channel on Slack called #domainexpertquestions which will be monitored by the Red Cross and the Core team. The purpose of this channel is for the contributors to post domain-related questions, all technical discussions should take place in other channels.

*SMS Gateway*
A new volunteer is investigating whether the organization he works with can act as a sponsor for CBSv2. Having him onboard will be very valuable, as he has great insight into the SMS gateways available for all countries and how to minimize the cost.

### MVP / Roadmap

We are in need of more detailed user stories, as it is currently difficult to understand the scope of the MVP and to determine the roadmap. 
Within a couple of weeks, the Red Cross will have a workshop with UX to go through all the required user stories for the MVP. We will no longer have user stories as issues in GitHub, we will rather include them under Documentation as markdown. Karoline will join the workshop so that she can create technical issues for the developers to work on. 
This will give us insight into when we can expect the MVP to be finished and whether we should move the User Management bounded context into one (or more?) of the other bounded contexts.

The Red Cross wants feedback from the contributors on whether we should do more weekend codeathons, shorter evening sessions or similar. What is the most efficient way of reaching our MVP?

### Setup in Azure
Priority number 1 from the contributor side going forward will be to get the applications up and running in Azure, both so that the Red Cross can follow the development and to simplify the frontend development as we can then point the frontend towards the backend running in Azure. 
Karoline has access to the Red Cross Azure subscription and she will work with Jessica to get this up and running. 
To get the dev environment up and running, we will need to build the docker images during build with semver versioning, and ensure all projects are setup in Travis and CircleCI. 

### Prioritized next steps

*Authentication*: Einar will focus on authenticating with Azure AD B2E & B2C.
*Setup in Azure*: Karoline and Jessica will get a working dev environment up and running in Azure.
*User stories*: Alexander will do a workshop with the Red Cross. Karoline will participate from the core team. 

