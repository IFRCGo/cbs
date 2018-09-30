/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterDataCollector extends Command
{
    constructor() {
        super();
        this.type = '2631542b-7cb6-45c3-b839-5c31b609f647';

        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.fullName = '';
        this.displayName = '';
        this.yearOfBirth = 0;
        this.sex = {};
        this.preferredLanguage = {};
        this.gpsLocation = {};
        this.phoneNumbers = [];
        this.region = '';
        this.district = '';
    }
}