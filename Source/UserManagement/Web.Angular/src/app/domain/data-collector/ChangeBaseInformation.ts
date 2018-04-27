import { Command } from '../../services/Command';
import { Sex } from '../sex';


export class ChangeBaseInformation extends Command {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: Sex;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-ChangeBaseInformation+Command|Domain';
    }
}
