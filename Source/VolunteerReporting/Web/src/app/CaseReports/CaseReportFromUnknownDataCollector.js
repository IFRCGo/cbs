/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class CaseReportFromUnknownDataCollector extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '7da7b4a4-bbe0-4b00-8fc7-b905e873e9c5',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.message = '';
        this.origin = '';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.numberOfFemalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfMalesUnder5 = 0;
        this.timestamp = new Date();
    }
}