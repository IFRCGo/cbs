/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterDataCollector extends Command
{
    constructor() {
        super();
        this.type = '1c17ba79-c72f-40c3-a784-987bff737ccd';

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
        this.dataVerifierId = '00000000-0000-0000-0000-000000000000';
    }
}