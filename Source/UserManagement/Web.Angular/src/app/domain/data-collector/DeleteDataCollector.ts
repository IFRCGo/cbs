import { Command } from '../../services/Command';

export class DeleteDataCollector extends Command {
    dataCollectorId: string;

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector-DeleteDataCollector+Command|Domain';
    }
}
