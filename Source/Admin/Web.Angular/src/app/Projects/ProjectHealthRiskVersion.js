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
           id: '2a1f9ccc-d80c-4113-867a-8e9e3020c074',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.projectId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = {};
        this.effectiveFromTime = new Date();
    }
}