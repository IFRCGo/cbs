/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class ReceivedMessage extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '7dac8377-4e4b-453d-8b6a-bca11940b5c5',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.sender = '';
        this.text = '';
        this.received = new Date();
    }
}