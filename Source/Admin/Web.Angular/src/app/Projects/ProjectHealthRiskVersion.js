/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class ProjectHealthRiskVersion extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'e808ce3a-00c2-4c48-a969-5e6f5315e82c',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.projectId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = {};
        this.effectiveFromTime = new Date();
    }
}