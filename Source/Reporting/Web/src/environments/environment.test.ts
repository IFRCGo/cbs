import {CommandCoordinator} from '@dolittle/commands';
import {QueryCoordinator} from '@dolittle/queries';

export const environment = {
  production: false,
  api: '/reporting',
  commandCoordinatorType: CommandCoordinator,
  queryCoordinatorType: QueryCoordinator
};
