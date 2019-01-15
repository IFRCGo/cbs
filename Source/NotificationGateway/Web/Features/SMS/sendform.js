import { inject } from 'aurelia-dependency-injection';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { Guid } from '@dolittle/core';

import { SimulateReceivedMessage } from './SimulateReceivedMessage';
import { bindable } from 'aurelia-framework';

@inject(CommandCoordinator, QueryCoordinator)
@bindable('messagesent')
export class sendform {
    sender = '';
    text = '';
    
    constructor(commandCoordinator, queryCoordinator) {

        this._commandCoordinator = commandCoordinator;
        this._queryCoordinator = queryCoordinator;
    }

    sendmessage() {
        const cmd = new SimulateReceivedMessage();
        cmd.id = Guid.create();
        cmd.sender = this.sender;
        cmd.text = this.text;
        cmd.received = new Date();
        this._commandCoordinator.handle(cmd).then(result => {
            if (result.success && typeof(this.messagesent) === 'function') {
                this.messagesent({
                    result: result,
                    command: cmd,
                });
            }
        });
    }
}