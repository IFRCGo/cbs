import { Command } from '../../services/Command';
import { Sex } from '../sex';
import { Language } from '../language.model';
import { Location } from '../location.model';


export class RegisterDataCollector extends Command {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: Sex;
    preferredLanguage: Language;
    gpsLocation: Location;
    phoneNumbers: Array<string>;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-RegisterDataCollector+Command|Domain';
        this.gpsLocation = new Location();
    }
}
