import { Command } from '../../services/Command';

export class ChangeLocation extends Command {
    dataCollectorId: string;
    location: Location

    constructor() {
        super();
        this.type = 'CBS#VolunteerReporting.DataCollector-ChangeLocation+Command|Domain';
        this.location = new Location();
    }
}
