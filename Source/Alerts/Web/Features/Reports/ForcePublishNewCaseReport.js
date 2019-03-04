/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands/dist/commonjs';

export class ForcePublishNewCaseReport extends Command
{
    constructor() {
        super();
        this.type = 'f7faaee0-385f-43f9-9e30-9182e955fd7c';

        this.caseReportId = '00000000-0000-0000-0000-000000000000';
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.origin = '';
        this.message = '';
        this.numberOfMalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfFemalesAged5AndOlder = 0;
        this.longitude = 0;
        this.latitude = 0;
        this.timestamp = new Date();
    }
}