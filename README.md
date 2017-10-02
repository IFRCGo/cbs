# Community Based Surveillance (CBS)

## Build Status

| CI/CD Projects  | Status  |
|---|---|
| Appveyor (Example)  | [![Build status](https://ci.appveyor.com/api/projects/status/verl69fxww1xi5l3?svg=true)](https://ci.appveyor.com/project/RFMoore/cbs-c5ssa)  |
| VolunteerReporting  | [![Build status](https://ci.appveyor.com/api/projects/status/o77909lns7ubfxdl?svg=true)](https://ci.appveyor.com/project/RFMoore/cbs/build/1.1.0-30-nsotvffx)  |
| CircleCI (Example) | [![CircleCI](https://circleci.com/gh/sheeeng/cbs.png?style=shield&circle-token=df3dc5f6efbc2a267f7805f05a5e91d2878be9fd)](https://circleci.com/gh/sheeeng/cbs) |
| TravisCI (Example) | [![TravisCI Status](https://travis-ci.org/sheeeng/cbs.svg?branch=master)](https://travis-ci.org/sheeeng/cbs) |

![](https://img.shields.io/github/stars/ifrcgo/cbs.svg)
![](https://img.shields.io/github/forks/ifrcgo/cbs.svg)
![](https://img.shields.io/github/watchers/ifrcgo/cbs.svg)
![](https://img.shields.io/github/tag/ifrcgo/cbs.svg)
![](https://img.shields.io/github/release/ifrcgo/cbs.svg)
![](https://img.shields.io/github/issues/ifrcgo/cbs.svg)

## Setup Ci build for as new bounding context

1. Copy the `appveyor.yml` file from (Build/appveyor.yml) into the root source folder for the bounding context.
1. Change the `<BaseSourceFolder>` part under the `only_commits` section to the root source folder for the bounding context.
1. Change the two variable under the section `environment` with the relative path to the `bin` folder of the `web project` relative from `Build\build.cake`. the relative path to the solution file of the new bounding context relative from `Build\build.cake`. 

The folowing steps has to be done by a person with access to to CBS`s appveyor account.
Please remember to update the above links in the CI/CD status.

1. Create a new Project on `https://ci.appveyor.com`.
1. Add the path to the newly created yml file in the field `Custom configuration .yml file name` under the `General` tab

Done by a developer
1. Create the entry for the new bonding context in the `Build status` table on to of this page.

### Build Using Docker Container

* Build image: `./dockerize.sh`
* Run container: `./containerize.sh`
* Build example (inside container): `./build.sh`

After running `./dockerize.sh` script, you have a `<user/organization>/cbs-devel` image for building the project.
Folks with access to CBS's official accounts can publish the Docker images to Docker Hub.
Please remember to update the CI/CD pipeline to reflect the official Docker images.
Use `./containerize.sh` to access the terminal inside the container, created from `<user/organization>/cbs-devel` image.
On the terminal inside the container, use `./build.sh` to build the project.

Folks with access to CBS's official accounts can now add CI/CD builds to CircleCI/TravisCI.
Please remember to update the above links in the CI/CD status.

## Contributing

Read more about how you can [contribute](./Documentation/Contribution/contributing.md).
To learn more about the different project to contribute to, read [here](./Documentation/Projects/index.md).

## Getting started

Below are the steps you need to do to get started:

1. Get familiar with the [Architecture](./Documentation/Architecture/at_a_glance.md)
1. Get familiar with the [Fundamentals](./Documentation/Architecture/fundamentals.md)
1. Learn what [development tools](./Documentation/Contribution/development_environment.md) to use
1. Follow the [getting started](./Documentation/Contribution/getting_started.md)
