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
           id: '0f639a85-c41d-4d76-8591-b3e63a7e9ef6',
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