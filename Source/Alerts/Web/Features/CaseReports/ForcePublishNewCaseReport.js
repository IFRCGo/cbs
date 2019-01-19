/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Command Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Command } from  '@dolittle/commands';

export class ForcePublishNewCaseReport extends Command
{
    constructor() {
        super();
        this.type = '10a4d610-294a-4148-bd6b-74ff1a879d0d';

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