# CBS - Reporting
Standalone webapp running the Reporting bounded context in development mode. 
An NPM package will externally be published and added in the Navigation module, together with the rest of the bounded contexts. 

## Building and running 

#### Install dependencies
```sh 
$ npm install
```

#### Run locally
This will start a development server, using [Parcel bundler](https://parceljs.org/), a faster and no-config alternative to Webpack.

```sh 
$ npm start
```

#### Running NodeJS API server
The NodeJS API server (under development) provides a more fluent Restful API and also makes it much easier to write frontend end-to-end tests (using Nightwatch.js).
 
To start the server:
```sh
$ npm run node:server
``` 

## Development
...

## End-to-end Testing
This project has support for writing automated UI tests using [Nightwath.js](http://nightwatchjs.org) - an easy to use Node.js based end-to-end testing framework
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
