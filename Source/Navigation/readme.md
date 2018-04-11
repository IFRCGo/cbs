# Navigation

The navigation bar is a component in every bounded context.
In order to work efficiently with this locally you should set up a NPM link.

Open your console/terminal and navigate to the `Navigation` folder and then do:

```shell
$ npm link
```

Then navigate into the frontend folder that is using the navigation that you're
working on. E.g. `VolunteerReporting/Web.Angular`and then do:

```shell
$ npm link ../../Navigation
```

Important aspect of the link here is the relative path for it to pick up the correct one.


You can read more about Node Link [here](https://docs.npmjs.com/cli/link).