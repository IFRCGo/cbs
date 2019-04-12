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
           id: '1c999658-9eb3-413c-9154-6eaad3ddac8e',
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