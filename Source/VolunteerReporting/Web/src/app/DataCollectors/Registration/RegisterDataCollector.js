/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterDataCollector extends Command
{
    constructor() {
        super();
        this.type = '215c42dc-76ea-413f-a879-94d6a3044cd0';

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