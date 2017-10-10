# Volunteer Reporting

## Build status
[![Build status](https://ci.appveyor.com/api/projects/status/o77909lns7ubfxdl?svg=true)](https://ci.appveyor.com/project/RFMoore/cbs)

## Prerequisites

If you haven't already familiarized yourself with the [contributor guide](../../Documentation/Contribution/contributing.md), please do so before proceeding. Make sure the required [development environment](../../Documentation/Contribution/development_environment.md) has been set up.

## Running the application

This example application consists of the following: 
- MongoDB storage
- A .NET Core backend
- A Node.js/Angular.js frontend

If you want to try the example application end-to-end (from interacting with the UI to seeing data being stored in the database), you will need to build and run all three components above. If you are a frontend developer and you don't really care if data is persisted, you can ignore the database step. If you are a backend developer who is happy with trying out APIs through Swagger, you can ignore the frontend step.

Let's take a look at how to build and run each part of the application! 

### Step 1: Run MongoDB in a Docker container

If you don't mind losing all your data when the container is shut down: 
> docker run -p 27017:27017 mongo

If you want to persist the data created, add a volume to the container:
> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo

### Step 2: Building and running the .NET Core backend on your local machine

(Active path: `cbs\source\example`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`   

(Active path: `cbs\source\example\web`)  

Run locally
> `dotnet run`

Open browser at address http://localhost:5000/swagger to access Swagger.

### Step 3: Building and running the Node.js/Angular.js frontend on your local machine

(Active path: `cbs/Source/Example/Web.Angular`)

Restore dependencies
> `npm install`

Build and host locally
> `ng serve` or `npm start`

Open http://localhost:4200/ in your browser to access the UI. 

## Alternative ways of building and running the application

The above guide assumes you will build and run the backend on your local machine. If you prefer building and running it in a Docker container, you can do so by following the steps below.

### Building and running the .NET Core backend in a Docker container

(Active path: `cbs`)

Build image
> `./dockerize.sh`

Run container: 
> `./containerize.sh`

Build Example application (inside container)
> `./build.sh`

See  the [continuous integration](../../Documentation/Continuous%20Integration/overview.md) overview for more information.

### Building a Docker image:

Unix:
> `docker build -t <repo>/<image>:<version> -f ./Dockerfile ../../../`

Windows (Docker Linux Mode):
> `docker build -t <repo>/<image>:<version> -f ./Dockerfile ..\..\..\`