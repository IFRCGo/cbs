import { Command } from './Command';
import { Guid } from './Guid';

/**
 * Represents a request for issuing a {Command}
 */
export class CommandRequest {
    correlationId = '';
    type = '';
    content = {};

    /**
     * Creates a {CommandRequest} from a {Command}
     * @param {Command} command
     */
    static createFrom(command) {
        const request = new CommandRequest(command.type, command);
        return request;
    }

    /**
     * Initializes a new instance of {CommandRequest}
     * @param {string} type
     * @param {*} content
     */
    constructor(type, content) {
        this.correlationId = Guid.create();
        this.type = type;
        this.content = content;
    }
}
