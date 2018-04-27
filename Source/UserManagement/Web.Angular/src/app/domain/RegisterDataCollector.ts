import {  Command } from '../services/Command';
import { Location } from './location.model';

export class RegisterDataCollector extends Command {
    dataCollectorId: string;
    fullName: string;
    displayName: string;
    yearOfBirth: number;
    sex: string;
    preferredLanguage: string;
    gpsLocation: Location;
    phoneNumbers: Array<string>;
    registeredAt: Date;

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-RegisterDataCollector+Command|Domain';
        this.gpsLocation = new Location();
    }
}
