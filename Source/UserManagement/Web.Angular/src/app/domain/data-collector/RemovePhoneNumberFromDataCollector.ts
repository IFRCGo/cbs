import { Command } from '../../services/Command';

export class RemovePhoneNumberFromDateCollector extends Command {
    dataCollectorId: string;
    phoneNumber: string;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-RemovePhoneNumberFromDataCollector+Command|Domain';
    }
}
