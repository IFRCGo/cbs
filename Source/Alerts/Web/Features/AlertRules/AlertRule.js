/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels/dist/commonjs';

export class AlertRule extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '86714ff6-4085-4204-8ab9-9d3b9ea2f9bb',
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