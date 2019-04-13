import { MockCommandCoordinator } from "../mocking/MockCommandCoordinator";
import { MockQueryCoordinator } from "../mocking/MockQueryCoordinator";
import {CommandCoordinator} from '@dolittle/commands'
import {QueryCoordinator} from '@dolittle/queries'

let _commandCoordinator;
let _queryCoordinator
//TODO: Mocks should be used when we are in "mock mode", not just in development. For Dakar codeathon it was sufficent with just development
if (process.env && process.env.NODE_ENV && process.env.NODE_ENV === 'development') {
    _commandCoordinator = new MockCommandCoordinator();
    _queryCoordinator = new MockQueryCoordinator();
}
else {
    _commandCoordinator = new CommandCoordinator();
    _queryCoordinator = new QueryCoordinator();
    _commandCoordinator.apiBaseUrl = process.env.API_BASE_URL;
    _queryCoordinator.apiBaseUrl = process.env.API_BASE_URL;
}

export const commandCoordinator = _commandCoordinator;
export const queryCoordinator = _queryCoordinator;