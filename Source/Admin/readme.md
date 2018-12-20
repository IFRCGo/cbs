# Admin

## Build status

[![Build status](https://cbsrc.visualstudio.com/cbs/_apis/build/status/Admin%20CI)](https://cbsrc.visualstudio.com/cbs/_build/latest?definitionId=0)

## Prerequisites

If you haven't already familiarized yourself with the [contributor guide](../../Documentation/Contribution/contributing.md), please do so before proceeding. Make sure the required [development environment](../../Documentation/Contribution/development_environment.md) has been set up.

See if you can find an issue labeled "good first issue" relating to this project [here.](https://github.com/IFRCGo/cbs/issues?utf8=%E2%9C%93&q=is%3Aopen+label%3A%22good+first+issue%22+project%3AIFRCGo%2Fcbs%2F1)

## Running the application

The Admin application consists of the following: 
- MongoDB storage
- A .NET Core backend
- A Node.js/Angular.js frontend

If you want to try the application end-to-end (from interacting with the UI to seeing data being stored in the database), you will need to build and run all three components above. If you are a frontend developer and you don't really care if data is persisted, you can ignore the database step. If you are a backend developer who is happy with trying out APIs through Swagger, you can ignore the frontend step.

Let's take a look at how to build and run each part of the application. 

### Step 1: Run MongoDB in a Docker container

If you don't mind losing all your data when the container is shut down: 
> docker run -p 27017:27017 mongo

If you want to persist the data created, add a volume to the container:
> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo

### Step 2: Building and running the .NET Core backend on your local machine

(Active path: `cbs\Source\Admin`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`   

(Active path: `cbs\Source\Admin\Web`)  

Run locally
> `dotnet run`

Open browser at address http://localhost:5001/swagger to access Swagger.

### Step 3: Building and running the Node.js/Angular.js frontend on your local machine

(Active path: `cbs/Source/Admin/Web`)

Restore dependencies
> `npm install`

Build and host locally
> `npm start`

Open http://localhost:4200/ in your browser to access the UI. 

## Populating the database with test data

To populate the database with test data, go to http://localhost:5001/swagger and use the TestDataGenerator API. This will retrieve test data from the /Web/TestData folder and add it to the database. 
> `/api/Dolittle/Commands
> `{
> `"correlationId": "510ef709-01ce-4255-9459-a70a274bcbe4",
> `"type": "269f0087-f2a7-4fce-bfb6-5a136d614201",
> `"content": {}
> `}

or

> `{
> `"correlationId": "510ef709-01ce-4255-9459-a70a274bcbe4",
> `"type": "c60d8362-ab0b-4537-8913-75212990200f",
> `"content": {}
> `}