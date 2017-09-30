# VolunteerReporting

## Prerequisites

Read up on the [development environment](../../Documentation/Contribution/development_environment.md)

## Running the application 

### Start your MongoDB

Solution uses Mongo - run it with the following:
(Active path: Anything)

> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo

The datadir option will give you a persistent storage for any data you put in.

## Local build (backend)

(Active path: `cbs\source\example`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`

Run locally
(Active path: `cbs\source\example\web`)

> `dotnet run`

Open browser at address http://localhost:5000 (as this is the backend, this address will not give you anything)

## Local build (frontend)

(Active path: `cbs/Source/Example/Web.Angular`)

> `ng serve` or `npm start`

### Building the Docker image:

Unix:
> `docker build -t <repo>/<image>:<version> -f ./Dockerfile ../../../`

Windows (Docker Linux Mode):
> `docker build -t <repo>/<image>:<version> -f ./Dockerfile ..\..\..\`