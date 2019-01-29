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
           id: '3af9fb50-1c7f-403c-8b01-4df63caa3182',
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