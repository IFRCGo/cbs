# CBS Example backend application

[![Build status](https://ci.appveyor.com/api/projects/status/aymmq31lpjdsxk6v?svg=true)](https://ci.appveyor.com/project/karolikl/cbs)

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