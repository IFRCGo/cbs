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
           id: 'a72c0cd7-b4f1-4c8b-a8c1-09bfa4ef5a51',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.projectId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = {};
        this.effectiveFromTime = new Date();
    }
}