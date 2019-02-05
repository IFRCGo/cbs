/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class AgeAndSexDistribution extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '97056220-5a4f-4443-92f4-3132e6b9d59d',
           generation: '1'
        };
        this.numberOfMalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfFemalesAged5AndOlder = 0;
        this.from = new Date();
        this.to = new Date();
    }
}