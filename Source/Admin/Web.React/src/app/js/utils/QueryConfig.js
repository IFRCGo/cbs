
import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import config from '../../../config';

console.warn(config.apiGateway.URL);

const { URL } = config.apiGateway;

QueryCoordinator.apiBaseUrl = URL;
CommandCoordinator.apiBaseUrl = URL;

var queryCoordinator = new QueryCoordinator();


export default queryCoordinator.execute;