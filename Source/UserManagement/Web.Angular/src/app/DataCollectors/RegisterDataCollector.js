/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class RegisterDataCollector extends Command
{
    constructor() {
        super();
        this.type = '0683e31a-02b1-4ac6-9d42-d2aa699ce77c';

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