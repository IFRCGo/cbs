# User management

## Build status
[![Build status](https://cbsrc.visualstudio.com/cbs/_apis/build/status/User%20Management%20CI)](https://cbsrc.visualstudio.com/cbs/_build/latest?definitionId=3)

## Prerequisites

If you haven't already familiarized yourself with the [how to contribute guide](https://github.com/IFRCGo/cbs/wiki/How-to-contribute), please do so before proceeding. 

See if you can find an issue labeled "good first issue" relating to this project [here.](https://github.com/IFRCGo/cbs/issues?utf8=%E2%9C%93&q=is%3Aopen+label%3A%22good+first+issue%22+project%3AIFRCGo%2Fcbs%2F2+)

## Running the application

You have a few options when running the application: 
- Run locally
- Run locally using docker-compose

### Run locally

The User Management application consists of the following: 
- MongoDB storage
- A .NET Core backend
- A Node.js/Angular.js frontend

If you want to try the application end-to-end (from interacting with the UI to seeing data being stored in the database), you will need to build and run all three components above. If you are a frontend developer and you don't really care if data is persisted, you can ignore the database step. If you are a backend developer who is happy with trying out APIs through Swagger, you can ignore the frontend step.

Let's take a look at how to build and run each part of the application! 


#### Step 1: Run MongoDB in a Docker container

If you don't mind losing all your data when the container is shut down: 
> docker run -p 27017:27017 mongo

If you want to persist the data created, add a volume to the container:
> docker run -p 27017:27017 -v /my/own/datadir:/data/db mongo

#### Step 2: Building and running the .NET Core backend on your local machine

This can also be done automatically by running the solution in Visual Studio. Make sure that you are running the project as "Web" and not "IIS Express".

(Active path: `cbs\Source\UserManagement`)

Download nuget dependencies
> `dotnet restore`

Build
> `dotnet build`   

(Active path: `cbs\Source\UserManagement\Web`)  

Run locally
> `dotnet run`
Open browser at address http://localhost:5002/swagger to access Swagger.

#### Step 3: Building and running the Node.js/Angular.js frontend on your local machine

(Active path: `cbs/Source/Admin/Web.Angular`)

Restore dependencies
> `npm install`

Build and host locally
> `npm start`

Open http://localhost:4202/ in your browser to access the UI. 

### Run locally using docker-compose

Note: Make sure you have [docker-compose](https://docs.docker.com/compose/) installed.

(Active path: 'cbs/Source/Admin')

Build the images: 'docker-compose build'
Run the images: 'docker-compose up'

Open http://localhost:4202/ in your browser to access the UI. 
The backend APIs are available on http://localhost:5002/ (Swagger is unavailable, use Postman or a similar tool)

## Populating the database with test data

To populate the database with test data, go to http://localhost:5002/swagger and use the POST /api/Dolittle/Commands API. This will retrieve test data from the /Domain/Tests\Data folder and add it to the database. 

Create DataCollector testdata: "269f0087-f2a7-4fce-bfb6-5a136d614201"
```
{
  "correlationId": "8d7bc6a3-c8fb-487f-84f2-c133057074d9", 
   "type": "8d7bc6a3-c8fb-487f-84f2-c133057074d9",
   "content": {}
}
```
