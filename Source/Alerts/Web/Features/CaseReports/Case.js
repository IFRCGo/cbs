/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class Case extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '14671609-5572-4932-9210-4268b62b1a9d',
           generation: '1'
        };
        this.caseReportId = '00000000-0000-0000-0000-000000000000';
        this.ageGroup = {};
        this.sex = {};
        this.latitude = 0;
        this.longitude = 0;
        this.timestamp = new Date();
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskNumber = 0;
        this.originPhoneNumber = '';
    }
}