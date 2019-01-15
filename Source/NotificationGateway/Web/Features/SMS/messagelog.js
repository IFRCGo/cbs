import { inject } from 'aurelia-dependency-injection';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { Guid } from '@dolittle/core';

import { AllReceivedMessages } from './AllReceivedMessages';

@inject(CommandCoordinator, QueryCoordinator)
export class messagelog {
    messages = []
    
    constructor(commandCoordinator, queryCoordinator) {
        this._commandCoordinator = commandCoordinator;
        this._queryCoordinator = queryCoordinator;

        this.updateMessages();
    }

    updateMessages() {
        var query = new AllReceivedMessages();
        this._queryCoordinator.execute(query).then(result => {
            this.messages = result.items;
        });
    }

    newMessageSent(command) {
        this.messages.unshift(command);
    }
}