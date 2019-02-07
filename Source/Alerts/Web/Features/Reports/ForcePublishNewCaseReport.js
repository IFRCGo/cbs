/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands/dist/commonjs';

export class ForcePublishNewCaseReport extends Command
{
    constructor() {
        super();
        this.type = '3e0652fd-e8ca-42a8-8275-e42560a8bb21';

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