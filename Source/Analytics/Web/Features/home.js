import { inject } from 'aurelia-dependency-injection';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

@inject(CommandCoordinator, QueryCoordinator)
export class home {
    
    constructor(commandCoordinator, queryCoordinator) {

        this._commandCoordinator = commandCoordinator;
        this._queryCoordinator = queryCoordinator;
    }
}