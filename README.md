# Community Based Surveillance

## Build status
| Project  | AppVeyor Status  |
|---|---|
| Example  | [![Build status](https://ci.appveyor.com/api/projects/status/aymmq31lpjdsxk6v?svg=true)](https://ci.appveyor.com/project/karolikl/cbs)  |

## Setup Ci build for as new bounding context
1. Copy the `appveyor.yml` file from (Build/appveyor.yml) into the root source folder for the bounding context.
1. Change the `<BaseSourceFolder>` part under the `only_commits` section to the root source folder for the bounding context.

The folowing steps has to be done by a person with access to to CBS`s appveyor account.
1. Create a new Project on `https://ci.appveyor.com`.
1. Add the path to the newly created yml file in the field `Custom configuration .yml file name` under the `General` tab
1. Add a Environment variable `WebBinFolder` with the relative path to the `bin` folder of the `web project` relative from `Build\build.cake`.
1. Add a Environment variable `SlnFile` with the relative path to the solution file of the new bounding context relative from `Build\build.cake`.
1. Create the entry for the new bonding context in the `Build status` table on to of this page.


## Contributing

Read more about how you can [contribute](./Documentation/Contribution/contributing.md).
To learn more about the different project to contribute to, read [here](./Documentation/Projects/index.md).

## Getting started

Below are the steps you need to do to get started:

1. Get familiar with the [Architecture](./Documentation/Architecture/at_a_glance.md)
1. Get familiar with the [Fundamentals](./Documentation/Architecture/fundamentals.md)
1. Learn what [development tools](./Documentation/Contribution/development_environment.md) to use
1. Follow the [getting started](./Documentation/Contribution/getting_started.md)
