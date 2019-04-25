/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class CaseReport extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'c416cbb9-ec8f-4acf-ba18-bd1559f9da8f',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.message = '';
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.numberOfFemalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfMalesUnder5 = 0;
        this.timestamp = new Date();
        this.location = {};
    }
}