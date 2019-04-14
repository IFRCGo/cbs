import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

export const environment = {
  production: false,
  api: 'http://demo.cbsrc.org',
  commandCoordinatorType: CommandCoordinator,
  queryCoordinatorType: QueryCoordinator
};
