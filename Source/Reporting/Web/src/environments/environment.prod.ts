import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

export const environment = {
  production: true,
  api: 'http://dev.cbsrc.org/reporting',
  commandCoordinatorType: CommandCoordinator,
  queryCoordinatorType: QueryCoordinator
};
