/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class AlertRule extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'a5d2e59e-1059-4da1-bca9-12a8fe2b1d03',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.alertRuleName = '';
        this.healthRiskId = 0;
        this.numberOfCasesThreshold = 0;
        this.distanceBetweenCasesInMeters = 0;
        this.thresholdTimeframeInHours = 0;
    }
}