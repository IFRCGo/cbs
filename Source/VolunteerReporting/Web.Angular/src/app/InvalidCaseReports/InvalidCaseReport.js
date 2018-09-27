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
           id: '42c4dcae-8fbf-4e12-a157-c62da9d7f5d7',
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