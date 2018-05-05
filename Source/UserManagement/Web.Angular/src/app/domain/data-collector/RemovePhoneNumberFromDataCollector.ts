import { Command } from '../../services/Command';

export class RemovePhoneNumberFromDataCollector extends Command {
    dataCollectorId: string;
    phoneNumber: string;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-RemovePhoneNumberFromDataCollector+Command|Domain';
    }
}
