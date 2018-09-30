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
           id: '3f84cb2d-8c54-49ef-b2a2-b7e9780fc955',
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