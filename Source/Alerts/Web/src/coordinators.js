import { MockCommandCoordinator } from "../mocking/MockCommandCoordinator";
import { MockQueryCoordinator } from "../mocking/MockQueryCoordinator";
import {CommandCoordinator} from '@dolittle/commands'
import {QueryCoordinator} from '@dolittle/queries'

let _commandCoordinator;
let _queryCoordinator
if ( process.env.MOCK_COORDINATORS == 'true') {
    console.log("Using mock");
    _commandCoordinator = new MockCommandCoordinator();
    _queryCoordinator = new MockQueryCoordinator();
}
else {
    console.log("NOT Using mock", process.env.API_BASE_URL);
    _commandCoordinator = new CommandCoordinator();
    _queryCoordinator = new QueryCoordinator();
    CommandCoordinator.apiBaseUrl = process.env.API_BASE_URL;
    QueryCoordinator.apiBaseUrl = process.env.API_BASE_URL;
}

export const commandCoordinator = _commandCoordinator;
export const queryCoordinator = _queryCoordinator;