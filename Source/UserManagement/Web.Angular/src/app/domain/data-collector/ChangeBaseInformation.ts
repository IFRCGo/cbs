import { Command } from '../../services/Command';
import { Sex } from '../sex';


export class ChangeBaseInformation extends Command {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: number;

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector-ChangeBaseInformation+Command|Domain';
    }
}
