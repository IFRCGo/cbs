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
           id: '7e69abf1-16db-4db8-b79b-050815033912',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.name = '';
        this.dataOwner = {};
        this.nationalSociety = {};
        this.surveillanceContext = {};
        this.healthRisks = [];
        this.dataVerifiers = [];
        this.smsProxy = '';
    }
}