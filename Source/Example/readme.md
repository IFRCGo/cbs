# CBS Example backend application

## Build status
| Project  | AppVeyor Status  |
|---|---|
| Example  | [![Build status](https://ci.appveyor.com/api/projects/status/verl69fxww1xi5l3?svg=true)](https://ci.appveyor.com/project/tksoftware/cbs)  |
| VolunteerReporting  | [![Build status](https://ci.appveyor.com/api/projects/status/o77909lns7ubfxdl?svg=true)](https://ci.appveyor.com/project/RFMoore/cbs/build/1.1.0-30-nsotvffx)  |


## Prerequisites

Read up on the [development environment](../../Documentation/Contribution/development_environment.md)

## Mongo Database

Solution uses Mongo - run it with the following:

> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo

> [!Note]
> You will need to create a new database called `shopping` within the database, with a tool like MongoChef/Studio 3T.

The datadir option will give you a persistent storage for any data you put in.

## Local build

(Active path: `cbs\source\example`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`

Run locally
(Active path: `cbs\source\example\web`)

> `dotnet run`

Open browser at address http://localhost:5000