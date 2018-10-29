
import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import config from '../../config'; 

console.warn(config.apiGateway.URL);

QueryCoordinator.apiBaseUrl = config.apiGateway.URL;
CommandCoordinator.apiBaseUrl = config.apiGateway.URL;

var queryCoordinator = new QueryCoordinator(config.apiGateway.URL); 


export default queryCoordinator;