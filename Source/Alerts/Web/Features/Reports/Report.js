/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class Report extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '25a45178-8c6f-4205-be5d-ff3a9eac93c2',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.caseReportId = '00000000-0000-0000-0000-000000000000';
        this.ageGroup = 0;
        this.sex = 0;
        this.latitude = 0;
        this.longitude = 0;
        this.timestamp = new Date();
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskNumber = 0;
        this.originPhoneNumber = '';
    }
}