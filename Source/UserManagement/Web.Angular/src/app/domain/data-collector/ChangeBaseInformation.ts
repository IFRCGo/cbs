import { Command } from '../../services/Command';
import { Sex } from '../sex';


export class ChangeBaseInformation extends Command {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: number;

    region: string;
    district: string;

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector.Changing-ChangeBaseInformation+Command@1';
    }
}
