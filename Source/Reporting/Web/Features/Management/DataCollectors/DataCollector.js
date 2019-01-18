/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class DataCollector extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'd46b3ba2-fab9-4f4d-9afe-0e98bbe3935f',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.fullName = '';
        this.displayName = '';
        this.yearOfBirth = 0;
        this.sex = {};
        this.preferredLanguage = {};
        this.location = {};
        this.district = '';
        this.region = '';
        this.village = '';
        this.phoneNumbers = [];
        this.registeredAt = new Date();
        this.dataVerifier = '00000000-0000-0000-0000-000000000000';
        this.inTraining = false;
    }
}