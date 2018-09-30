/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class InvalidCaseReport extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '0b131a41-0828-4354-9f75-df0d9718f5d0',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.origin = '';
        this.message = '';
        this.parsingErrorMessage = [];
        this.timestamp = new Date();
    }
}