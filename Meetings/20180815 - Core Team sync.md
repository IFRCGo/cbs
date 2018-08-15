# Core team sync, 15.08.2018

## Participants
* Alexander
* Bjørn
* Einar
* Hodo
* Jørgen
* Karoline
* Sindre

## Agenda

* Codeathon 3.0
* General update

## Before Codeathon 3.0
Planning workshop on September 6th. Everyone should have received an invite for this from Rebecca.

We need to create projects for the new bounded contexts before the codeathon.  

Invites to the codeathon. Dolittle has been very active in recruiting consulting companies, we all need to share the codeathon with our network. 

## Updates from the Core team:

**Hodo & Alexander is working on "Building our story"**
- Continuing the work of documenting personas
- Storyboards / infographics
- Would like to focus on creating a styleguide (similar to https://design.sparebank1.no/) during the codeathon to document the graphic design. Styleguidist can be used for this. 

**Update from Dolittle:** 
	- Monitoring with alerts is set up
	- Kafka has been replaced 
	- Working with the underlying data store
	- Improvements related to authorization and authentication
	- Multi-tenancy

**SMS Gateway**
	- Cisco not an option. 
	- Continuing w/ SMS Eagle, at least until other options arise.
	- Bjørn is in discussions with Twilio, they support more countries than listed. The Red Cross could get access to this. 

**Front-end frameworks**
Opening up for other front-end frameworks in new bounded contexts, such as React. This requires a rewrite of the navigation bar, but this will not be a problem as the authentication changes from Dolittle will take authentication logic away from front-end. 

**Milestone 4**
The following will be done before the codeathon by Dolittle: 
	- Persistant Storage
	- Event storage
	- Logging framework

Pushed "Setup test and production environment" to Milestone 5. 