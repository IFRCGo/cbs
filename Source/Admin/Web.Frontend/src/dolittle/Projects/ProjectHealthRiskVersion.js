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
           id: '883b13b3-ee32-4d86-93ac-7022384e4ba7',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.projectId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = {};
        this.effectiveFromTime = new Date();
    }
}