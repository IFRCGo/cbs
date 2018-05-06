import { Command } from '../../services/Command';

export class AddPhoneNumberToDataCollector extends Command {
    dataCollectorId: string;
    phoneNumber: string;

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector-AddPhoneNumberToDataCollector+Command|Domain';
    }
}
