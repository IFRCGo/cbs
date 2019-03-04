/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels/dist/commonjs';

export class DataCollector extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '34be7eab-82e9-477c-9d39-0c9b763cad28',
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
        this.lastReportRecievedAt = new Date();
        this.extraElements = [];
    }
}