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
           id: '777df906-2a3e-4b5d-9bf1-ce0df9f99dd6',
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