# CBS - Alerts
Standalone React-based webapp running the __Alerts Bounded Context__ (module) in development mode. For more info on Bounded Contexts, see https://martinfowler.com/bliki/BoundedContext.html.

Like the other bounded contexts (Reporting, Admin, Analytics), Alerts runs independent and an NPM package will exported. This package will automatically be picked by the Navigation module, together with the rest of the bounded contexts.
You don't have to do anything in this respect, everything it's taken care by the build system, once the changes are pushed to Git. 

## Install dependencies
Assuming Node.js and NPM (or Yarn) are installed on your machine, this will install everything needed to run and develop the project locally on your machine.

```sh 
$ npm install
```

## Running
This will start a frontend development server, using [Parcel bundler](https://parceljs.org/). Parcel is a faster and no-config alternative to Webpack.
In addition, a NodeJS API server will also be started in parallel, which will communicate with the Backend services. The NodeJS server, as well as the Parcel dev server, can also be run separate.

```sh 
$ npm start
```

You can navigate to http://localhost:1234 in your browser to view the application. 

### Using a fake backend
The NodeJS API server includes a test data file which can be used to fake the backend requests. To use it, run:

```sh
$ npm run start:local
```

#### Running the NodeJS API server
The NodeJS API server provides a more fluent Restful API and also makes it much easier to write frontend end-to-end tests (using Nightwatch.js).
It is a shared module between all the Bounded Contexts and it is located under `Source/Navigation/Web.NodeJS`.
 
To start the server:
```sh
$ npm run node:server
``` 

## Development

### Hot Module Reloading
In many cases, changes in the React components should automatically be available on the page without having to reload the page.

### Common React Components
A set of common React components and Sass style is located under `Source/Navigation/Web.Common` and it is shared among all the Bounded Contexts. 
When installing locally, NPM will compile the sources from Web.Common as a local dependency (`@ifrc-cbs/common-react-ui`), using Babel. 

This will happen automatically, but it's important to note that if you modify the source folder (`src`) in the Web.Common module, you will need to run `npm install` again to re-compile it.

## End-to-end Testing
The project has support for writing automated UI tests using [Nightwath.js](http://nightwatchjs.org) - an easy to use Node.js based end-to-end testing framework
using the Webdriver API or Selenium.

### Running the tests
The tests by default will run in Chrome (headless mode). Nightwatch will start/stop ChromeDriver automatically and also start/stop the 
Parcel development server and NodeJS API server as needed.

The NodeJS API server mocked the calls to the backend and returns JSON output directly, for convenience. 
```sh
$ npm test
```

### Writing tests
New UI tests should be added to `test/src`. For more information about writing tests using Nightwatch, please refer to the [Nightwath docs(http://nightwatchjs.org/guide).

## Troubleshooting build issues
__npm install fails__

Sometimes running `npm install` will fail with unexpected, inexplicable error conditions. The errors are mostly related to
`babel-cli` or `npm` itself. If this occurs, try the following:

1. open `package.json` and delete the line which contains the `@ifrc-cbs/common-react-ui` dependency (make sure to delete the comma 
which precedes it);
2. run `npm install`;
3. add the line containing the `@ifrc-cbs/common-react-ui` dependency back and run `npm install` again.

__Parcel bundler errors__

Sometimes, particularly when changes in external components occur, running the development server (with Parcel) can produce errors.
You can try:

1. remove the `.cache` folder (this is where Parcel keeps its data for faster processing)
2. restart `npm run dev` process.    
