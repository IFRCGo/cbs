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
           id: '1cc91e9e-5aae-47f3-82c4-98ddf22fc353',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.sender = '';
        this.text = '';
        this.received = new Date();
    }
}