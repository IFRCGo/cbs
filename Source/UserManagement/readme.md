# User management

## Prerequisites

Read up on the [development environment](../../Documentation/Contribution/development_environment.md)

## Mongo Database

Solution uses Mongo - run it with the following:

> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo
(Create an empty folder for the mongo and make sure you don't already have a running db)

> [!Note]
> You will need to create a new database called `usermanagement` within the database, with a tool like MongoChef/Studio 3T.

The datadir option will give you a persistent storage for any data you put in.

## Local build

(Active path: `cbs\source\usermanagement\`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`

Run locally
(Active path: `cbs\source\usermangement\web`)

> `dotnet run`

Open browser at address http://localhost:5000

## Run frontend
Navigate to the Web.Angular project
First time run:

> `npm install`

Then to start the frontend 
> `npm start`
