/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands/dist/commonjs';

export class CreateAlertRule extends Command
{
    constructor() {
        super();
        this.type = 'f1c0f0da-f5b8-4bed-b013-0953f3a9a4d0';

        this.id = '00000000-0000-0000-0000-000000000000';
        this.alertRuleName = '';
        this.numberOfCasesThreshold = 0;
        this.thresholdTimeframe = new Date();
        this.healthRiskNumber = 0;
        this.distanceBetweenCasesInMeters = 0;
    }
}