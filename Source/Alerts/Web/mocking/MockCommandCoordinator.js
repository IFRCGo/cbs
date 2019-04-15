import { CommandRequest, Command } from '@dolittle/commands';

export class MockCommandCoordinator {

    /**
     * Handle a {Command}
     * @param {Command} command
     * @return {Promise<*>}
     */
    handle(command) {
        return new Promise((resolve, reject) => {
            resolve({
                command: CommandRequest.createFrom(command),
                validationResults: [],
                commandValidationMessages: [],
                securityMessages: [],
                allValidationMessages: [],
                exception: null,
                exceptionMessage: '',
                success: true,
                invalid: false,
                passedSecurity: true,
            });
        });
    }
}