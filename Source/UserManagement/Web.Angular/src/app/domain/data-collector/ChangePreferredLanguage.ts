import { Command } from '../../services/Command';
import { Language } from '../language.model';

export class ChangePreferredLanguage extends Command {
    dataCollectorId: string;
    preferredLanguage: number

    constructor() {
        super();
        this.type = 'CBS#UserManagement.DataCollector.Changing-ChangePreferredLanguage+Command@1';
    }
}
