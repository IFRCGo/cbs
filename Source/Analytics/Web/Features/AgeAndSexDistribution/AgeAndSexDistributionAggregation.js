/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class AgeAndSexDistributionAggregation extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '26251c6e-f1ff-4fb5-a9b2-183fdcf1011e',
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