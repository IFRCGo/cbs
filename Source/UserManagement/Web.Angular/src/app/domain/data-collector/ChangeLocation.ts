import { Command } from '../../services/Command';
import {Location} from '../location.model'
export class ChangeLocation extends Command {
    dataCollectorId: string;
    location: Location

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector.Changing-ChangeLocation+Command@1';
        this.location = new Location();
    }
}
