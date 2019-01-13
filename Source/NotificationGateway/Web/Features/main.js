import environment from './environment';
import { PLATFORM } from 'aurelia-pal';
import * as Bluebird from 'bluebird';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

CommandCoordinator.apiBaseUrl = environment.apiBaseUrl;
QueryCoordinator.apiBaseUrl = environment.apiBaseUrl;

// remove out if you don't want a Promise polyfill (remove also from webpack.config.js)
Bluebird.config({ warnings: { wForgottenReturn: false } });

export function configure(aurelia) {
  aurelia.use
    .standardConfiguration();

  if (environment.debug) {
    aurelia.use.developmentLogging();
  }
  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
