import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

export const environment = {
  production: true,
  api: 'http://dev.cbsrc.org/reporting',
  commandCoordinatorType: CommandCoordinator,
  queryCoordinatorType: QueryCoordinator,
  appInsightsInstrumentationKey: 'ca4137d7-10b6-4f10-a75b-5b915d96fedb'
};
