import {  Command } from '../services/Command';
import { Location } from './location.model';
import { Sex } from './sex';
import { Language } from './language.model';

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
