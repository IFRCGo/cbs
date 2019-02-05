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
           id: '893b09bd-5d69-4a05-bc2a-420ba95cd169',
           generation: '1'
        };
        this.numberOfMalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfFemalesAged5AndOlder = 0;
        this.timestamp = new Date();
        this.healthRisk = '00000000-0000-0000-0000-000000000000';
        this.longitude = 0;
        this.latitude = 0;
    }
}