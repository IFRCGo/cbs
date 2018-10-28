
import { QueryCoordinator } from '@dolittle/queries';
import config from '../../config'; 

console.warn(config.apiGateway.URL);

var queryCoordinator = new QueryCoordinator(config.apiGateway.URL); 
queryCoordinator.apiBaseUrl = config.apiGateway.URL;

export default queryCoordinator;