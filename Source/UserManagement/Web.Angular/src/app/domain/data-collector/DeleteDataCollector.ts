import { Command } from '../../services/Command';

export class DeleteDataCollector extends Command {
    dataCollectorId: string;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-DeleteDataCollector+Command|Domain';
    }
}
