---
title: About container usage
description: Details about container usage
keywords: Docker, Container
author: fredrkl, einari
---
# Containers

Containers bring to the industry a new way of building and deploying applications. Whereas before you had a clear separation between developers and operation, containers often bring these to together to form DevOps people. In addition containers eliminate to a large extend the "it works on my machine" problem. Or "it builds on my machine" type problems.

Whereas we before shipped code in packages we now move towards shipping containers. You can look at a containers as a placeholder for you code with instructions on how to setup the environment for the code to run. A container does not have any dependencies besides the container runtime. Using docker that will be the docker engine. The corollary is a development practice where we ship self describing containers where we can be confident that it will run in any environment as long as docker engine is installed.

Docker is the de-facto standard for building images, and starting/stopping containers. There are other standards such as rkt, but we will be using Docker.

As VMWare significantly reduced the IT costs by running several OS´s on single hardware, Containers take this a step further. Containers use virtualization on the OS level to create user spaces. So for a container it will look like it is running on a separate machine. Containers are significantly faster to spin up compared to Virtual machines, you only pay for one OS license instead of one per VM, and you use your expensive hardware to a greater degree on running your applications instead of Operating Systems.

Containers is used strategically in the project as a means of having both flexibility but also clear boundaries for what is deployable units.

## Installing Docker

Just go to docker store and [download it](https://store.docker.com/search?type=edition&offering=community) for your OS.

## Mini-guide to using Docker

Once Docker is installed you bring up your favorite Terminal. Run

```
$ docker version
```

If it is installed correctly you will be presented with version info of the client and the server. Client is the CLI that you just used, and server is also installed on your machine(the whale icon). We send commands to the docker server by the CLI.

### Running your first container

To run your first container you simply type:

```
$ docker run hello-world
```

As you can see from the output docker first tries to find the image locally, then it tries to get it from the docker hub. You can find the image hello-world at [https://store.docker.com/images/hello-world](https://store.docker.com/images/hello-world)

## Registry

Registries are a central concept in docker. This is where you store your images. The ones you create yourself and others. When we ran the example above we pulled the image from the centralized docker hub, stored it our local registry and ran it. Run

```
$ docker images
```

to see the images that you have locally. If you run the hello-world example again, it will find the image locally and skip the pulling from docker hub.

We will for CBS create our own registry. Take a look at [docker store](https://store.docker.com/search?source=verified&type=image) to see examples of images from the official docker hub.

## Storage in containers

```
$ docker ps
```

Will show the containers running on your computer. You can also run:

```
$ docker ps -a
```

to also see the containers that have been stopped. Once you delete a container then all data that is stored inside it will be lost. One approach that we will be using is to store the data outside of the containers. One example could be to run a container with a Sql-server instance and a database. We can specify volumes to a container that acts as outside directories. Lets look at an example:

```
docker run -it --name teamcity-server-instance  \
    -v <path to data directory>:/data/teamcity_server/datadir \
    -v <path to logs directory>:/opt/teamcity/logs  \
    -p <port on host>:8111 \
    jetbrains/teamcity-server
```

Here we see that we specify the directories using the -v parameter.

Another approach is to send in as a parameter to the container a separate service that store the data, e.g., Azure SQL Connection string.

## Versioning

We tag images when we create them. The two most regular tags are "latest" and version number. We use the following scheme:

major.minor.revision.build

Major is only incremented once a full new version is released that is controlled by the marketing department or introduces breaking changes to earlier releases.

Minor is increased when introducing new features.

revision is used to indicate bug fixes.

build is an auto-incremented number that comes from the build server.

To tag an image you simply use the tag command:

```
docker tag 0e5574283393 fedora/httpd:version1.0
```

Here we tag a local image 0e5574283393 intro the fedora repository with version1.0. However the most usual is to tag an image during build:

```
docker build -t cbdIdentity:0.1.0 .
```

So build a new image from the Dockerfile in the current directory with the repository name cbdIdentity and tag it with 0.1.0.

## Deployment

Deployment of containers is done in CBS with Kubernetes .yaml files. See [Kubernetes](./kubernetes.md) for more documentation.

## Reference

* [https://docs.docker.com/reference/](https://docs.docker.com/reference/)

## Hand on lab

If you want to get more familiar with Docker, there is a set of labs you can find [here](http://github.com/msdevno/docker-on-azure-hol).