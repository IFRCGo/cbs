/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels/dist/commonjs';

export class Report extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '1b55e958-24d5-4b19-b70c-d77a7a141052',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
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