import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

export const environment = {
  production: false,
  api: 'http://demo.cbsrc.org',
  commandCoordinatorType: CommandCoordinator,
  queryCoordinatorType: QueryCoordinator,
  appInsightsInstrumentationKey: '36bdf7e0-884f-4391-8f08-11ebd48b9023'
};
