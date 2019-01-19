/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class UpdateAlertRule extends Command
{
    constructor() {
        super();
        this.type = '8616098d-0bbc-4285-81e0-05bb68cd576b';

        this.id = '00000000-0000-0000-0000-000000000000';
        this.alertRuleName = '';
        this.numberOfCasesThreshold = 0;
        this.thresholdTimeframe = new Date();
        this.healthRiskId = 0;
        this.distanceBetweenCasesInMeters = 0;
    }
}