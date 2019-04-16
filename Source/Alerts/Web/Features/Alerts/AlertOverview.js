/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class AlertOverview extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'c0d41bba-a379-4c8a-9c41-4d563fdeb5f3',
           generation: '1'
        };
        this.alertNumber = 0;
        this.healthRiskNumber = 0;
        this.healthRiskName = '';
        this.numberOfReports = 0;
        this.openedAt = new Date();
        this.status = {};
    }
}