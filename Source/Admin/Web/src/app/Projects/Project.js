/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class Project extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '63ff50bc-0cab-4af8-9f7d-deb6ba5b1367',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.name = '';
        this.dataOwner = {};
        this.nationalSociety = {};
        this.surveillanceContext = 0;
        this.healthRisks = [];
        this.dataVerifiers = [];
        this.smsProxy = '';
    }
}